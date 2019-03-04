using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rehber.Database.Models;

namespace Rehber.WebAPP.Controllers
{
    public class UnitsController : Controller
    {
        RehberContext _db;

        public UnitsController(RehberContext Db)
        {
            _db = Db;
        }


        public JsonResult Get()
        {
            var list = _db.Units.ToList();
            return Json(list);
        }

        public JsonResult GetById(int unitId)
        {
            var unit = _db.Units.Where(x => x.UnitId == unitId).SingleOrDefault();
            return Json(unit);
        }
    }
}