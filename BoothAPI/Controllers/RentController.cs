using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoothAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        IRent _re;
        public RentController(IRent re)
        {
            _re = re;
        }
        public List<OrderInfo> RentShow()
        
        {
            List<OrderInfo> list = _re.RentShow();

            return list;
        }
    }
}