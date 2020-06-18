using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BoothAdmin.Controllers
{
    public class RentController : Controller
    {
        public IActionResult ConTastShow()
        {
            return View();
        }
        public IActionResult InsertRent()
        {
            return View();
        }
        public IActionResult RentShow()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}