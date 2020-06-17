using IBoothDataAccess;
using System;

namespace IBoothService
{
    public interface IBase
    {
        IRepository<T> CreateService<T>() where T : class, new();
    }
}
