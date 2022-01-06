using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Northwind.Dal.Abstract;
using Northwind.Dal.Concrete.Entityframework.Repository;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.Entityframework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Variables
        DbContext context;
        IDbContextTransaction transaction;
        bool _dispose;
        #endregion

        #region Constructor
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        #endregion

        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        protected virtual void Dispose(bool ddisposing)
        {
            if (!this._dispose)
            {
                if (ddisposing)
                {
                    context.Dispose();
                }
            }

            this._dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(context);
        }
        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int SaveChanges()
        {
            var _transaction = transaction != null ? transaction : context.Database.BeginTransaction();
            try
            {
                if (context == null)
                {
                    throw new ArgumentException("Context is null");
                }
                var result = context.SaveChanges();
                _transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error on save changes", ex);
            }
        }
    }
}
