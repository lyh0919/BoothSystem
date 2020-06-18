using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BoothAdmin.Controllers
{
    public class RentController : Controller
    {
        public IActionResult InsertRent()
        {
            return View();
        }
        /// <summary>
        /// 竞拍单详情
        /// </summary>
        /// <returns></returns>
        public IActionResult RentShow()
        {
            return View();
        }
        /// <summary>
        /// 反填订单详情
        /// </summary>
        /// <returns></returns>
        public IActionResult Update()
        {
            return View();
        }
        /// <summary>
        /// 合同管理
        /// </summary>
        /// <returns></returns>
        public IActionResult ConTastShow()
        {
            return View();
        }
    }
}