using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SalaryController : Controller
    {
        private readonly IUnitOfWork _db;
        public SalaryController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public IActionResult Index()
        {
            var User = _db.salary.GetAll().ToList();

            return View(User);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateUser(PayElementMaster Pay)
        {
            Pay.CreatedDateTime = DateTime.Now;

            _db.salary.Add(Pay);
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

            var user = _db.salary.Get(U => U.PayElementId == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(PayElementMaster Pay)
        {

            Pay.ModifiedDateTime = DateTime.Now;

            _db.salary.Update(Pay);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var pay = _db.salary.Get(E => E.PayElementId == id);

            if (User != null)
            {
                _db.salary.Remove(pay);
            }

            _db.Save();

            return RedirectToAction("Index");
        }
    }
}
