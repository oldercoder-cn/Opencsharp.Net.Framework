using Data.DbFactory;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Dapper;

namespace Data.Orm.Dapper
{
    public class SqlServerDatabase : IDatabase
    {
        public string connectionString { get; set; }
        protected DbConnection Connection
        {
            get
            {
                DbConnection dbconnection = new SqlConnection(connectionString);
                dbconnection.Open();
                return dbconnection;
            }
        }
        public SqlServerDatabase(string conn)
        {
            connectionString = conn;
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
            using (var connection = Connection)
            {
                connection.Execute(commandText);
            }
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
