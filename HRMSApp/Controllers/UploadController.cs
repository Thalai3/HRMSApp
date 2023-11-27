using HRMS.DataAccess.Data;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    public class UploadController : Controller
    {
        private readonly HrmsAppDbContext _context; 
        private readonly IWebHostEnvironment _environment;

        public UploadController(HrmsAppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;                
        }

        public IActionResult Index(int id)
        {
            var candidate = _context.Candidates.FirstOrDefault(x => x.Id == id);
            ViewBag.candidatedata = candidate;

            return View();
        }

        public IActionResult UploadFile(int id)
        
        {
            var candidateId = _context.Candidates.FirstOrDefault(x => x.Id == id);
            return View(candidateId);  
        }

        [HttpPost]
        public IActionResult UploadFile(Uploadfiles uploadfiles) 
        {
            string webRootPath = _environment.WebRootPath;

            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newFileName = "CandidateDocument";
                var path = Path.Combine(webRootPath, @"Document\Candidate");

                var extension = Path.GetExtension(file[0].FileName);

                using (var filestream = new FileStream(Path.Combine(path, newFileName + extension), FileMode.Create))
                {
                    file[0].CopyTo(filestream);
                }
                uploadfiles.Upload = @"\Document\Candidate\" + newFileName + extension;
                uploadfiles.Is_Active = "1";

                if (ModelState.IsValid)
                {
                    _context.Add(uploadfiles);
                    _context.SaveChanges();
                    TempData["success"] = "Candidate Document Uploaded Successfully";

                }
            }
            
            return View(uploadfiles);
        }
    }
}
