﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BoothAdmin.Controllers
{
    public class BoothController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //显示微信会员信息
        public IActionResult ShowWeiXin()
        {
            return View();
        }

    }
}