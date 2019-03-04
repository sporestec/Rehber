using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rehber.Admin.Models;
using Rehber.Database.Models;

namespace Rehber.WebAPP.Controllers
{
    public class PersonnelsController : Controller
    {
        RehberContext _db;

        public PersonnelsController(RehberContext Db)
        {
            _db = Db;
        }

        public JsonResult SearchByNameAndUnitId(string name, int unitId = 0)
        {
            var list = from us in _db.Users
                       join un in _db.Units on us.UnitId equals un.UnitId
                       where

                       (us.FirstName.Contains(name) || us.LastName.Contains(name))
                       && (unitId == 0 || us.UnitId == unitId)
                       select new PersonnelViewModel()
                       {
                           Email = us.Email,
                           ExtraInfo = us.ExtraInfo,
                           FirstName = us.FirstName,
                           LastName = us.LastName,
                           TelephoneNumber = us.TelephoneNumber,
                           UnitId = us.UnitId,
                           UnitName = un.UnitName,
                           UserId = us.UserId,
                           WebSite = us.WebSite
                       };

            return Json(list);
        }

        public JsonResult GetById(int unitId)
        {
            var unit = _db.Units.Where(x => x.UnitId == unitId).SingleOrDefault();
            return Json(unit);
        }
    }
}