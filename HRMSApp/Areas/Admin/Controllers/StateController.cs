using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StateController : Controller
    {
        private readonly IUnitOfWork _db;
        public StateController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public IActionResult Index()
        {
            var User = _db.state.GetAll().ToList();

            return View(User);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateUser(StateMaster stateMaster)
        {
            stateMaster.CreatedDateTime = DateTime.Now;

            _db.state.Add(stateMaster);
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

            var user = _db.state.Get(U => U.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(StateMaster stateMaster)
        {

            stateMaster.ModifiedDateTime = DateTime.Now;

            _db.state.Update(stateMaster);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var User = _db.state.Get(E => E.Id == id);

            if (User != null)
            {
                _db.state.Remove(User);
            }

            _db.Save();

            return RedirectToAction("Index");
        }
    }
}

