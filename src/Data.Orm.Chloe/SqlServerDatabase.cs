using Chloe;
using Chloe.SqlServer;
using Data.DbFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Orm.Chloe
{
    public class SqlServerDatabase : IDatabase
    {
        static MsSqlContext db;
        static string connStr;
        public SqlServerDatabase(string conn)
        {
            connStr = conn;
            db = new MsSqlContext(conn);
        }

        public IDatabase BeginTrans()
        {
            return null;
        }
        public int Commit()
        {
            return 0;
        }
        public void Rollback()
        {

        }


        public void Select(string commandText)
        {
            db.QueryByKey<object>("");
        }

        public void Insert(string commandText)
        {
            Console.WriteLine(string.Format("'{0}' is a insert sql in !", commandText));
        }

        public void Update(string commandText)
        {
            Console.WriteLine(string.Format("'{0}' is a update sql in !", commandText));
        }

        public void Delete(string commandText)
        {
            Console.WriteLine(string.Format("'{0}' is a delete sql in !", commandText));
        }
    }
}
