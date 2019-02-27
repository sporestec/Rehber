using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rehber.Database.Models;

namespace Rehber.Database.Controllers
{
    public class HomeController : Controller
    {
        private readonly RehberContext rehberContext;
        public HomeController(RehberContext context)
        {
            rehberContext = context ?? throw new ArgumentNullException(nameof(context));
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
