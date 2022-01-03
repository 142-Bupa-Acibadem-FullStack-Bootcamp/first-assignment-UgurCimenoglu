using Northwind.Dal.Abstract;
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
        public bool BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            throw new NotImplementedException();
        }

        public bool RollBackTransaction()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
