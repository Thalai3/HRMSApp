using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StatusController : Controller
    {
        private readonly IUnitOfWork _db;
        public StatusController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public IActionResult Index()
        {
            var User = _db.status.GetAll().ToList();

            return View(User);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateUser(StatusMaster statusMaster)
        {
            statusMaster.CreatedDateTime = DateTime.Now;

            _db.status.Add(statusMaster);
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

            var user = _db.status.Get(U => U.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(StatusMaster statusMaster)
        {

            statusMaster.ModifiedDateTime = DateTime.Now;

            _db.status.Update(statusMaster);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var User = _db.status.Get(E => E.Id == id);

            if (User != null)
            {
                _db.status.Remove(User);
            }

            _db.Save();

            return RedirectToAction("Index");
        }
    }
}
