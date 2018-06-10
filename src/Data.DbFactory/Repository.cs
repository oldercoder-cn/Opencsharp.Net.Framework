using Autofac;
using Autofac.Core;
using BaseUtility.Ioc;

namespace Data.DbFactory
{
    /// <summary>
    /// 统一的对外数据仓库
    /// </summary>
    public class Repository
    {
        private static IDatabase db;

        public Repository(string dbInstance)
        {
            db = BaseUtility.Ioc.AutofacHelper.GetDbInstance<Data.DbFactory.IDatabase>(dbInstance);
        }

        public Repository(string dbInstance,string connStr)
        {
            Data.DbFactory.IDatabase database = BaseUtility.Ioc.AutofacHelper.GetDbInstance<Data.DbFactory.IDatabase>(dbInstance,
                new ResolvedParameter(
           (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "conn",//该参数与构造函数的参数名称要保持一致
           (pi, ctx) => connStr)
                );
        }



        #region 事物
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
        #endregion 事物

        #region CRUD
        public void Select(string commandText)
        {
            db.Select(commandText);
        }

        public void Insert(string commandText)
        {
            db.Insert(commandText);
        }

        public void Update(string commandText)
        {
            db.Update(commandText);
        }

        public void Delete(string commandText)
        {
            db.Delete(commandText);
        }
        #endregion CRUD
    }
}
