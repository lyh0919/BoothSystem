using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoothService
{
    public class Show:Base,IShow
    {
        public Show(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {
        }

        public List<RbacDeptPart> GetDept()
        {
            var service = this.CreateService<RbacDeptPart>();
            return service.GetAll().ToList();
        }
    }
}
