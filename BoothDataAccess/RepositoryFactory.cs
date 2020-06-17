using System;
using System.Collections.Generic;
using System.Text;
using IBoothDataAccess;

namespace BoothDataAccess
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<T> CreateRepository<T>(IBoothManageContext mydbcontext) where T : class, new()
        {
            return new Repository<T>(mydbcontext);
        }
    }
}
