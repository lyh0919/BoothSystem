using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BoothAdmin.Controllers
{
    public class RbacController : Controller
    {
        public IActionResult DeptIndex()
        {
            return View();
        }
        public IActionResult RoleIndex()
        {
            return View();
        }
        public IActionResult PowerIndex()
        {
            return View();
        }
    }
}
