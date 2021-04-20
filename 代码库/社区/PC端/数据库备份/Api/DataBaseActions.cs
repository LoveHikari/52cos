using System;
using System.IO;

namespace Api
{
    public sealed class DataBaseActions
    {
        private static volatile DataBaseActions _instance = null;
        private static readonly object lockHelper = new object();

        private DataBaseActions()
        {
        }

        public int BackUPDB(string connStr, string dbName)
        {
            string directory = "C:\\DbBack";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            DateTime nowTime = DateTime.Now;
            SqlHelper sqlHelper = new SqlHelper(connStr);
            string fileName = "ManualBack_" + nowTime.ToString("yyyyMMddHHmmssfff") + "_" + dbName;
            string path = directory + "\\" + fileName + ".bak";
            string sql = $"BACKUP DATABASE ESSoft2 TO disk = '{path}' WITH FORMAT, NAME = '{fileName}'";
            return sqlHelper.ExecSqlNonQuery(sql);
        }

        public static DataBaseActions Instance
        {
            get
            {
                if (_instance == null)
                {
                    object lockHelper = DataBaseActions.lockHelper;
                    lock (lockHelper)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataBaseActions();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}

