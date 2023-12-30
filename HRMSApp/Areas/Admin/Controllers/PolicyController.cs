using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PolicyController : Controller
    {
        private readonly IUnitOfWork _db;
        public PolicyController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public IActionResult Index()
        {
            var User = _db.policy.GetAll().ToList();

            return View(User);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateUser(LeavePolicyMaster leavePolicy)
        {
            leavePolicy.CreatedDateTime = DateTime.Now;

            _db.policy.Add(leavePolicy);
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

            var user = _db.policy.Get(U => U.LeavePolicyId == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(LeavePolicyMaster leavePolicy)
        {

            leavePolicy.ModifiedDateTime = DateTime.Now;

            _db.policy.Update(leavePolicy);
            _db.Save();

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var Policy = _db.policy.Get(E => E.LeavePolicyId == id);

            if (User != null)
            {
                _db.policy.Remove(Policy);
            }

            _db.Save();

            return RedirectToAction("Index");
        }
    }
}
