using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LeavePolicyController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly HrmsAppDbContext _tbl;
        public LeavePolicyController(IUnitOfWork unitOfWork, HrmsAppDbContext tbl)
        {
            _db = unitOfWork;
            _tbl = tbl;
        }       
        public IActionResult Index()
        {
            var strucutre = _db.leavePolicy.GetAll().ToList();

            return View(strucutre);
        }
       
        public IActionResult Create()
        {
            var status = _tbl.tbl_PayElementMaster.Where(S => S.IsActive == true).Select(E => E.PayElements).ToList();
            ViewBag.status = status;

            return View();
        }
        public IActionResult CreateUser(LeavePolicy leavePolicy)
        {

            leavePolicy.CreatedDateTime = DateTime.Now;    

            _db.leavePolicy.Add(leavePolicy);
            _db.Save();

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

            var leavePolicy = _db.leavePolicy.Get(U => U.Id == id);

            if(leavePolicy == null)
            {
                return NotFound();
            }
        
            return View(leavePolicy);
        }
        [HttpPost]
        public IActionResult EditUser(LeavePolicy leavePolicy) 
        {
            //user.UserName = user.FirstName + " " + user.LastName;
            leavePolicy.ModifiedDateTime = DateTime.Now; 
            
            _db.leavePolicy.Update(leavePolicy);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var structure = _db.leavePolicy.Get(E => E.Id == id);

            if (structure != null)
            {
                _db.leavePolicy.Remove(structure);
            }

            _db.Save();

            return RedirectToAction("Index");           
        }

    }
}
