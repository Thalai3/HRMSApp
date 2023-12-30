using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _db;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public IActionResult Index()
        {
            var User = _db.role.GetAll().ToList();

            return View(User);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateUser(RoleMaster RoleMaster)
        {
            RoleMaster.CreatedDateTime = DateTime.Now;

            _db.role.Add(RoleMaster);
            _db.Save();

            TempData["success"] = "Candidate Added Successfully";

            return RedirectToAction("Index");

            //return View(user);  
        }
        public IActionResult EditUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var user = _db.role.Get(U => U.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(RoleMaster RoleMaster)
        {

            RoleMaster.ModifiedDateTime = DateTime.Now;

            _db.role.Update(RoleMaster);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var User = _db.role.Get(E => E.Id == id);

            if (User != null)
            {
                _db.role.Remove(User);
            }

            _db.Save();

            return RedirectToAction("Index");
        }
    }
}
