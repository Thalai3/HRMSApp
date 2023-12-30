using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly HrmsAppDbContext _tbl;
        public UserController(IUnitOfWork unitOfWork, HrmsAppDbContext tbl)
        {
            _db = unitOfWork;
            _tbl = tbl;
        }       
        public IActionResult Index()
        {
            var User = _db.user.GetAll().ToList();

            return View(User);
        }
       
        public IActionResult Create()
        {
            var status = _tbl.tbl_StatusMaster.Where(S => S.IsActive == true).Select(E => E.Status).ToList();
            ViewBag.status = status;

            return View();
        }
        public IActionResult CreateUser(User user)
        {

            user.UserName = user.FirstName+" "+user.LastName;
            user.CreatedDateTime = DateTime.Now;    

            _db.user.Add(user);
            _db.Save();

            TempData["success"] = "Candidate Added Successfully";

            return RedirectToAction("Index");  

            //return View(user);  
        }
        public IActionResult EditUser(int? id) 
        {
            if(id == null || id == 0)
            {
                return NotFound();  
            }
            var status = _tbl.tbl_StatusMaster.Where(S => S.IsActive == true).Select(E => E.Status).ToList();
            ViewBag.status = status;

            var user =_db.user.Get(U => U.Id == id);

            if(user == null)
            {
                return NotFound();
            }
        
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(User user) 
        {
            user.UserName = user.FirstName + " " + user.LastName;
            user.ModifiedDateTime = DateTime.Now; 
            
            _db.user.Update(user);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var User = _db.user.Get(E => E.Id == id);

            if (User != null)
            {
                _db.user.Remove(User);
            }

            _db.Save();

            return RedirectToAction("Index");           
        }

    }
}
