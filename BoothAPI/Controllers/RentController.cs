using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothAPI.ViewModel;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoothAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private IRent _rent;
        private IMarketBll _market;
        public RentController(IRent rent, IMarketBll market)
        {
            _rent = rent;
            _market = market;
        }

        //显示
        
    }
}