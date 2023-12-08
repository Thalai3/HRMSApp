using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    public class CityController : Controller
    {
        private readonly IUnitOfWork _db;
        public CityController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public IActionResult Index()
        {
            var User = _db.city.GetAll().ToList();

            return View(User);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateUser(CityMaster cityMaster)
        {
            cityMaster.CreatedDateTime = DateTime.Now;

            _db.city.Add(cityMaster);
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

            var user = _db.city.Get(U => U.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(CityMaster cityMaster)
        {

            cityMaster.ModifiedDateTime = DateTime.Now;

            _db.city.Update(cityMaster);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var User = _db.city.Get(E => E.Id == id);

            if (User != null)
            {
                _db.city.Remove(User);
            }

            _db.Save();

            return RedirectToAction("Index");
        }
    }
}
