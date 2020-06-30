using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BoothAdmin.Controllers
{
    public class RentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OrderDesc()
        {
            return View();
        }
        public IActionResult ContractsManager()
        {
            return View();
        }
        public IActionResult OrderActionList()
        {
            return View();
        }
    }
}
