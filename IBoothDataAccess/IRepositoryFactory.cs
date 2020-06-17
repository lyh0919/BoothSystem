using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothDataAccess
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>(IBoothManageContext mydbcontext) where T : class,new();
    }
}
