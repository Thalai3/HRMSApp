using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRMSApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _db;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public IActionResult Home()
        {
           return View();       
        }
        public IActionResult Login(string Email,string Password)
        {

            var User = _db.user.Get(E =>E.Email ==Email && E.Password == Password );

            if (User == null)
            {
                TempData["warning"] = "Invalid Email and Password";
            }
            if (User != null)
            {
                TempData["success"] = "Login Successfully";

                return RedirectToAction("Index", "Home");
            }
          
               return View("Home");
            
        }
        public IActionResult Register()
        {
            return RedirectToAction("Create","User");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}