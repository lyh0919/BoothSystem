using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace BoothService
{
    public class CityBll :Base,ICity
    {
        public CityBll(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {

        }
        public List<City> ShowArea(object id)
        {
            using (SqlConnection conn = new SqlConnection("server=192.168.1.130;database=BoothManage;uid=sa;pwd=123456;"))
            {
                string sql = "select * from City where pid="+id+"";
                return conn.Query<City>(sql).ToList();
            }
        }

        public List<City> ShowCity(object id)
        {
            using (SqlConnection conn = new SqlConnection("server=192.168.1.130;database=BoothManage;uid=sa;pwd=123456;"))
            {
                string sql = "select * from City where PId=" + id+"";
                return conn.Query<City>(sql).ToList();
            }
        }

        public List<City> ShowProvince()
        {
            using (SqlConnection conn = new SqlConnection("server=192.168.1.130;database=BoothManage;uid=sa;pwd=123456;"))
            {
                string sql = "select * from City where pid=1";
                return conn.Query<City>(sql).ToList();
            }
        }
    }
}
