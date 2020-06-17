using IBoothDataAccess;
using IBoothService;
using System;

namespace BoothService
{
    public class Base: IBase
    {
        private IRepositoryFactory _repositoryFactory;
        private IBoothManageContext _mydbcontext;
        public Base(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext)
        {
            this._repositoryFactory = repositoryFactory;
            this._mydbcontext = mydbcontext;
        }

        public IRepository<T> CreateService<T>() where T : class, new()
        {
            return _repositoryFactory.CreateRepository<T>(_mydbcontext);
        }
    }
}
