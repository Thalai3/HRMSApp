using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using HRMS.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HRMSApp.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SalaryStructureController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly HrmsAppDbContext _tbl;
        public SalaryStructureController(IUnitOfWork unitOfWork, HrmsAppDbContext tbl)
        {
            _db = unitOfWork;
            _tbl = tbl;
        }       
        public IActionResult Index()
        {
            var strucutre = _db.salarystructure.GetAll().ToList();

            return View(strucutre);
        }
       
        public IActionResult Create()
        {
            //var status = _tbl.tbl_PayElementMaster.Where(S => S.IsActive == true).Select(E => E.PayElements).ToList();
            //ViewBag.status = status;

             IEnumerable<SelectListItem> status = _tbl.tbl_PayElementMaster.Where(S => S.IsActive == true)
                .Select(S => new SelectListItem
                {
                   Text = S.PayElements,
                   Value = S.PayElementId.ToString(),
                    Selected = S.IsActive
                }) ;
            //IEnumerable<SelectListItem> status = _db.salary.GetList().Where(S => S.IsActive == true)
            //    .Select(S => new SelectListItem
            //    { 
            //        Text = S.PayElements,
            //        Value = S.PayElementId.ToString(),
            //        Selected = S.IsActive
            //    });
            ViewBag.status = status;

            return View();

        }
        public IActionResult CreateUser(SalaryStructureVM salary)
        {
            foreach (var item in salary.structure)
            {
                item.CreatedDateTime = DateTime.Now;
                _db.salarystructure.Add(item);
                _db.Save();
            } 
            
            TempData["success"] = "SalaryStructure Added Successfully";

            return RedirectToAction("Index");  

            //return View(user);  
        }
        public IActionResult EditUser(int? id) 
        {
            if(id == null || id == 0)
            {
                return NotFound();  
            }
            var status = _tbl.tbl_PayElementMaster.Where(S => S.IsActive == true).Select(E => E.PayElements).ToList();
            ViewBag.status = status;

            var structure = _db.salarystructure.Get(U => U.Id == id);

            if(structure == null)
            {
                return NotFound();
            }
        
            return View(structure);
        }
        [HttpPost]
        public IActionResult EditUser(SalaryStructure Structure) 
        {
            //user.UserName = user.FirstName + " " + user.LastName;
            Structure.ModifiedDateTime = DateTime.Now; 
            
            _db.salarystructure.Update(Structure);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var structure = _db.salarystructure.Get(E => E.Id == id);

            if (structure != null)
            {
                _db.salarystructure.Remove(structure);
            }

            _db.Save();

            return RedirectToAction("Index");           
        }
        public IActionResult Upsert()
        {

            var structureVM = new SalaryStructureVM
            {
                structure = new List<SalaryStructure> { new SalaryStructure() }
            };

            IEnumerable<SelectListItem> status = _tbl.tbl_PayElementMaster.Where(S => S.IsActive == true)
               .Select(S => new SelectListItem
               {
                   Text = S.PayElements,
                   Value = S.PayElementId.ToString(),
                   Selected = S.IsActive
               });
            
            ViewBag.status = status;

            return View(structureVM);

        }
    }
}
