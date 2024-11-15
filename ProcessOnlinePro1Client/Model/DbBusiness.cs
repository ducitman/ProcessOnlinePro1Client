using DataBase.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessOnlinePro1Client.Model
{
    class DbBusiness:IDisposable
    {
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        public DataTable GetOldAndNewApplicationdateRevision(string materialSize, string machineGroup)
        {
            ConnectionManagement connectionManagement = new ConnectionManagement(ApplicationUtils.BOSS);
            DataTable tbl = new DataTable();

            try
            {
                string query = @"select * from(
                                    select A.PARTNUMBER, A.REVISIONNO, B.APPLICATIONDATE,ROW_NUMBER() OVER (PARTITION BY A.PARTNUMBER order by A.REVISIONNO DESC) as rn
                                    from SPEC.Z_SPECMTRLPROCESSSTATUS A 
                                    Join 
                                    SPEC.Z_SPECMTRLREVISION B
                                    ON 
                                    A.PARTNUMBER = B.PARTNUMBER and A.REVISIONNO = B.REVISIONNO and A.MACHINEGROUP = B.MACHINEGROUP
                                    where A.PARTNUMBER = '"+ materialSize +"' and A.APPROVESTATE = '9' and A.MACHINEGROUP = '"+ machineGroup +"' order by A.UPDATEDATE desc" +
                                    @")
                                    where ROWNUM <= 2 ";
                OracleCommand cmd = new OracleCommand(query, connectionManagement.GetOraConnection());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(tbl);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return tbl;
        }
        public DataTable GetCurrentSchedulelotData(string machineID, string machineGroup)
        {
            ConnectionManagement connectionManagement = new ConnectionManagement(ApplicationUtils.BOSS);
            DataTable tbl = new DataTable();
            try
            {
                string query = @"select DISTINCT MATERIALSIZE, MATERIALLOTNO,WORKINGDATETIME, SCHEDULEORDER,REVISIONNO,STATUSFLAG 
                            FROM
                                (SELECT TRIM(MTLS.PARTNUMBER) MATERIALSIZE, TRIM(MTLS.MATERIALLOTNUMBER) MATERIALLOTNO, MTLS.WORKINGDATETIME AS WORKINGDATETIME, MTLS.SCHEDULEORDER AS SCHEDULEORDER
                                ,LVER.REVISIONNO AS REVISIONNO,MTLS.STATUSFLAG AS STATUSFLAG
                                FROM BOSS.Z_MATERIALSCHEDULELOT MTLS
                                JOIN 
                                (SELECT A.PARTNUMBER, A.MACHINEGROUP, A.PARTID, A.REVISIONNO, A.PREVREVISIONNO, A. TRIALFLAG, B.applicationdate AS APPLICATIONDATE
                                FROM
                                (SELECT PARTNUMBER, MACHINEGROUP, PARTID, REVISIONNO, 
                                LAG(REVISIONNO, 1, 0) OVER (PARTITION BY PARTNUMBER ORDER BY REVISIONNO) AS PREVREVISIONNO, TRIALFLAG
                                FROM SPEC.Z_SPECMTRLPROCESSSTATUS 
                                WHERE APPROVESTATE = '9' AND MACHINEGROUP = '" + machineGroup + "')" +
                        @"      A JOIN (
                                SELECT A.Partnumber,b.applicationdate , MAX(A.REVISIONNO) AS REVISIONNO
                                FROM SPEC.Z_SPECMTRLPROCESSSTATUS A
                                JOIN SPEC.Z_SPECMTRLREVISION B ON A.Partnumber = B.Partnumber
                                WHERE A.ApproveState = '9'
                                  AND SUBSTR(B.APPLICATIONDATE, 1, 8) < TO_CHAR(SYSDATE, 'YYYYMMDD') 
                                  AND A.MACHINEGROUP = '"+machineGroup+"'"
                                + @" 
                                  group by a.partnumber, b.applicationdate
                                )B
                                ON B.PARTNUMBER = A.PARTNUMBER AND A.REVISIONNO = B.REVISIONNO) LVER
                                ON MTLS.PARTNUMBER = LVER.PARTNUMBER
                                WHERE MTLS.ACTUALMACHINEID = '" + machineID + "' AND MTLS.STATUSFLAG = '1')";
                OracleCommand cmd = new OracleCommand(query, connectionManagement.GetOraConnection());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(tbl);
            }
            catch(Exception ex)
            {
                throw ex;
            }   
            return tbl;
        }
        public DataTable GetLastestProcessVersion(string machineGroup)
        {
            ConnectionManagement connectionManagement = new ConnectionManagement(ApplicationUtils.BOSS);
            DataTable tbl = new DataTable();
            try
            {
                string query = @"SELECT A.PARTNUMBER, A.MACHINEGROUP, A.PARTID, A.REVISIONNO, A.PREVREVISIONNO, A. TRIALFLAG, B.LATEST_DATE AS APPLICATIONDATE
                                FROM
                                (SELECT PARTNUMBER, MACHINEGROUP, PARTID, REVISIONNO, 
                                LAG(REVISIONNO, 1, 0) OVER (PARTITION BY PARTNUMBER ORDER BY REVISIONNO) AS PREVREVISIONNO, TRIALFLAG
                                FROM SPEC.Z_SPECMTRLPROCESSSTATUS 
                                WHERE APPROVESTATE = '9' AND MACHINEGROUP = '" + machineGroup + "'" +
                                @" ) A JOIN
                                (
                                    SELECT p.PARTNUMBER, 
                                       p.MACHINEGROUP,
                                       p.REVISIONNO AS MAX_REVISIONNO,
                                       p.APPLICATIONDATE AS LATEST_DATE
                                    FROM (
                                      SELECT PARTNUMBER, 
                                             MACHINEGROUP,
                                             REVISIONNO,
                                             APPLICATIONDATE,
                                             RANK() OVER (PARTITION BY PARTNUMBER ORDER BY REVISIONNO DESC) AS RNK
                                      FROM SPEC.Z_SPECMTRLREVISION
                                      WHERE MACHINEGROUP = '" + machineGroup + "'" +
                                      @") p
                                    WHERE p.RNK = 1 AND TO_DATE(SUBSTR(p.APPLICATIONDATE, 1, LENGTH(p.APPLICATIONDATE)-1), 'YYYYMMDD') < SYSDATE
                                )B
                                ON B.PARTNUMBER = A.PARTNUMBER AND A.REVISIONNO = B.MAX_REVISIONNO";
                OracleCommand cmd = new OracleCommand(query, connectionManagement.GetOraConnection());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(tbl);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return tbl;
        }
        public bool isTerminalPC(string PCName)
        {
            bool rs = false;
            ConnectionManagement connectionManagement = new ConnectionManagement(ApplicationUtils.BOSS);
            DataTable tbl = new DataTable();
            try
            {
                string query = @"SELECT PCNAME,PARAMETER FROM Z_FAMACHINEPARAMETER where PCNAME = '" + PCName + "' and KEY = 'MACHINEID'";
                OracleCommand cmd = new OracleCommand(query, connectionManagement.GetOraConnection());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(tbl);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            if(tbl.Rows.Count > 0)
            {
                rs = true;
            }
            return rs;
        }
        public DataTable GetMachineData()
        {
            ConnectionManagement connectionManagement = new ConnectionManagement(ApplicationUtils.BOSS);
            DataTable tbl = new DataTable();
            try
            {
                string query = "SELECT MACHINEID,MACHINENAMESHORT,MACHINEGROUP FROM Z_MATERIALMACHINEMASTER order by MACHINEGROUP ASC";
                OracleCommand cmd = new OracleCommand(query, connectionManagement.GetOraConnection());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(tbl);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return tbl;
        }
        public DataTable GetNextSchedulelotData(string machineID, string machineGroup)
        {
            ConnectionManagement connectionManagement = new ConnectionManagement(ApplicationUtils.BOSS);
            DataTable tbl = new DataTable();
            try
            {
                string query = @"SELECT MATERIALSIZE, MATERIALLOTNO, WORKINGDATETIME, SCHEDULEORDER, REVISIONNO, STATUSFLAG
                                FROM (
                                SELECT TRIM(MTLS.PARTNUMBER) MATERIALSIZE, TRIM(MTLS.MATERIALLOTNUMBER) MATERIALLOTNO, MTLS.WORKINGDATETIME, MTLS.SCHEDULEORDER,LVER.REVISIONNO AS REVISIONNO,MTLS.STATUSFLAG
                                FROM BOSS.Z_MATERIALSCHEDULELOT MTLS
                                JOIN 
                                (SELECT A.PARTNUMBER, A.MACHINEGROUP, A.PARTID, A.REVISIONNO, A.PREVREVISIONNO, A. TRIALFLAG, B.LATEST_DATE AS APPLICATIONDATE
                                FROM
                                (SELECT PARTNUMBER, MACHINEGROUP, PARTID, REVISIONNO, 
                                LAG(REVISIONNO, 1, 0) OVER (PARTITION BY PARTNUMBER ORDER BY REVISIONNO) AS PREVREVISIONNO, TRIALFLAG
                                FROM SPEC.Z_SPECMTRLPROCESSSTATUS 
                                WHERE APPROVESTATE = '9' AND MACHINEGROUP = '" + machineGroup + "')" +
                        @"      A JOIN (
                                       SELECT p.PARTNUMBER, 
                                       p.MACHINEGROUP,
                                       p.REVISIONNO AS MAX_REVISIONNO,
                                       p.APPLICATIONDATE AS LATEST_DATE
                                    FROM (
                                      SELECT PARTNUMBER, 
                                             MACHINEGROUP,
                                             REVISIONNO,
                                             APPLICATIONDATE,
                                             RANK() OVER (PARTITION BY PARTNUMBER ORDER BY REVISIONNO DESC) AS RNK
                                      FROM SPEC.Z_SPECMTRLREVISION
                                      WHERE MACHINEGROUP = '" + machineGroup + "')" +
                        @"          p 
                                    WHERE p.RNK = 1 AND TO_DATE(SUBSTR(p.APPLICATIONDATE, 1, LENGTH(p.APPLICATIONDATE)-1), 'YYYYMMDD') < SYSDATE
                                )B
                                ON B.PARTNUMBER = A.PARTNUMBER AND A.REVISIONNO = B.MAX_REVISIONNO) LVER
                                ON MTLS.PARTNUMBER = LVER.PARTNUMBER
                                WHERE MTLS.ACTUALMACHINEID = '" + machineID + "' AND MTLS.STATUSFLAG IN ('0','4') AND MTLS.SCHEDULEORDER <> 0 ORDER BY MTLS.WORKINGDATETIME ASC) WHERE ROWNUM <= 1";
                OracleCommand cmd = new OracleCommand(query, connectionManagement.GetOraConnection());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(tbl);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return tbl;            
        }
        public DataTable GetMachineInformation(string machineID)
        {
            DataTable tbl = new DataTable();
            try
            {
                using (var connectionManagement = new ConnectionManagement(ApplicationUtils.BOSS))
                {
                    string query = @"Select A.PCNAME AS MACHINENAME, A.PARAMETER AS MACHINEID, B.MACHINEGROUP AS MACHINEGROUP FROM Z_FAMACHINEPARAMETER A
                                    JOIN Z_MATERIALMACHINEMASTER B
                                    ON A.PARAMETER = B.MACHINEID
                                    WHERE A.PCNAME = '"+ machineID + "' AND A.KEY = 'MACHINEID' ";
                    OracleDataAdapter adp = new OracleDataAdapter(query, connectionManagement.GetOraConnection());
                    adp.Fill(tbl);
                    adp.Dispose();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return tbl;
        }
    }
}
