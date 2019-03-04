using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rehber.Admin.Data;
using Rehber.Admin.Models;

namespace Rehber.Admin.Controllers
{
   
    public class PersonnelController : Controller

    {
        RehberDbContext db = new RehberDbContext();
        public IActionResult PersonnelMainPage()
        {
            return View();
        }

        public IActionResult GetAllPersonnels()
        {
            //var PersonnelList = from  user in db.Users join unit in db.Units on user.UnitId equals unit.UnitId select user;
            var PersonnelList = db.Users.Join(db.Units, use => use.UnitId, unit => unit.UnitId,
                (use, unit) => new PersonnelViewModel
                {
                    UserId = use.UserId,
                    UnitId = use.UnitId,
                    UnitName = unit.UnitName,
                    FirstName = use.FirstName,
                    LastName = use.LastName,
                    Email = use.Email,
                    ExtraInfo = use.ExtraInfo,
                    TelephoneNumber = use.TelephoneNumber,
                    WebSite = use.WebSite
                });
            return Json(PersonnelList);

        }

        [HttpPost]
     
        public JsonResult AddNewPersonnel([FromBody]PersonnelViewModel Personnel)
        {
            var unit = db.Units.Where(x => x.UnitName == Personnel.UnitName).FirstOrDefault();
            var user = new Users()
            {
                FirstName = Personnel.FirstName,
                LastName = Personnel.LastName,
                Email = Personnel.Email,
                ExtraInfo = Personnel.ExtraInfo,
                TelephoneNumber = Personnel.TelephoneNumber,
                WebSite = Personnel.WebSite,
                UnitId = unit.UnitId
            };
        
            db.Users.Add(user);
            //feef
            db.SaveChanges();
            Personnel.UserId = user.UserId;
            Personnel.UnitId = user.UnitId;

            return Json(Personnel);
        }


        public IActionResult DeletePersonnel(int PersonnelId)
        {

            var Person = db.Users.Where(x => x.UserId == PersonnelId).SingleOrDefault();
            db.Remove(Person);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult GetPersonnelId(int PersonnelId)
        {
            var personnel = db.Users.Where(x => x.UserId == PersonnelId).SingleOrDefault();
            var unit = db.Units.Where(x => x.UnitId == personnel.UnitId).SingleOrDefault();
            PersonnelViewModel personnelViewModel = new PersonnelViewModel()
            {
                Email = personnel.Email,
                TelephoneNumber = personnel.TelephoneNumber,
                FirstName = personnel.FirstName,
                LastName = personnel.LastName,
                UnitName = unit.UnitName,
                ExtraInfo = personnel.ExtraInfo,
                UserId = personnel.UserId,
                UnitId = unit.UnitId,
                WebSite = personnel.WebSite
                
            };
            return Json(personnelViewModel);
        }


        [HttpPost]
        public IActionResult SaveEditing([FromBody] PersonnelViewModel edtPersonnel)
        {
           
                var personnel = db.Users.Where(x => x.UserId == edtPersonnel.UserId ).SingleOrDefault();
                var unit = db.Units.Where(x => x.UnitName == edtPersonnel.UnitName).SingleOrDefault();
                personnel.FirstName = edtPersonnel.FirstName;
                personnel.LastName = edtPersonnel.LastName;
                personnel.Email = edtPersonnel.Email;
                personnel.WebSite = edtPersonnel.WebSite;
                personnel.TelephoneNumber = edtPersonnel.TelephoneNumber;
                personnel.UnitId = unit.UnitId;
                personnel.ExtraInfo = edtPersonnel.ExtraInfo;
                db.Update(personnel);
                db.SaveChanges();
                return Json(edtPersonnel);
          
        }
    }
}