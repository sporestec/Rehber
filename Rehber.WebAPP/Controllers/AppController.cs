using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rehber.WebAPP.Models;

namespace Rehber.WebAPP.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
