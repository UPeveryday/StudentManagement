﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class DepartMentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}