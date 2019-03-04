using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rehber.Admin.Data;

namespace Rehber.Admin.Controllers
{
    public class UnitController : Controller
    {

        RehberDbContext db = new RehberDbContext();
        public IActionResult UnitMainPage()
        {
            return View();
        }

        public JsonResult GetAllUnit()
        {
            var list = db.Units.ToList();
            return Json(list);
        }
        public JsonResult DeleteUnit(int unitId)
        {
          
        
            Units unit = db.Units.SingleOrDefault(x => x.UnitId == unitId);
            if (unit != null)
            {
                db.Units.Remove(unit);
                db.SaveChanges();
            }
            return Json("");
        }

        public JsonResult AddUnit(string unitName)
        {
            if (unitName != "")
            {
                Units unit = new Units();
                unit.UnitName = unitName;
                db.Units.Add(unit);
                db.SaveChanges();
                return Json(unit);
            }
            return Json("");
        }

        public JsonResult GetUnitById(int unitId)
        {

            var unit = db.Units.Where(x => x.UnitId == unitId).SingleOrDefault();
            return Json(unit);
            
        }

        public JsonResult SaveEditing(int unitId,String unitName )
        {
            var unit = db.Units.Where(x => x.UnitId == unitId).SingleOrDefault();
            unit.UnitName = unitName;
            db.Attach(unit);
            db.SaveChanges();
            return Json(unit);
        }
    }

}