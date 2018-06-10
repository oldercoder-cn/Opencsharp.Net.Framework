using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Data.DbFactory
{
    public interface IDatabase
    {
        #region 事物
        IDatabase BeginTrans();
        int Commit();
        void Rollback();
        #endregion 事物

        #region CRUD
        void Select(string commandText);

        void Insert(string commandText);

        void Update(string commandText);

        void Delete(string commandText);
        #endregion CRUD
    }
}
