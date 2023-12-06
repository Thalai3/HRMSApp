using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _db;
        public UserController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public IActionResult Index()
        {
            var User = _db.user.GetAll().ToList();

            return View(User);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateUser(User user)
        {
            _db.user.Add(user);
            _db.Save();

            return RedirectToAction("Index");  
            //return View(user);  
        }
        public IActionResult EditUser(int? id) 
        {
            if(id == null || id == 0)
            {
                return NotFound();  
            }

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
            _db.user.Update(user);
            _db.Save();

            return RedirectToAction("Index");

        }
        public IActionResult Remove()
        {



            return RedirectToRoute("Index");
        }

    }
}
