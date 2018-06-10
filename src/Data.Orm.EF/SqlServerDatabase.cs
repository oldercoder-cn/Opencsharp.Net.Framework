using Data.DbFactory;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Orm.EF
{
    public class SqlServerDatabase : IDatabase
    {
        //static string connection = @"Server=2013-20150707DJ\SQL2012EXPRESS;Database=AppDb;Trusted_Connection=True;";
        DbContext dbContext;
        public SqlServerDatabase(string conn)
        {
            DbContextOptions<DbContext> dbContextOption = new DbContextOptions<DbContext>();
            DbContextOptionsBuilder<DbContext> dbContextOptionBuilder = new DbContextOptionsBuilder<DbContext>(dbContextOption);
            dbContext = new DbContext(dbContextOptionBuilder.UseSqlServer(conn).Options);
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

        public T Select<T>(string commandText)
        {
            return dbContext.Set<TModel>().Select(commandText);
            //Console.WriteLine(string.Format("'{0}' is a query sql in EF!", commandText));
        }
        public void Select(string commandText)
        {
            Console.WriteLine(string.Format("'{0}' is a query sql in EF!", commandText));
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
