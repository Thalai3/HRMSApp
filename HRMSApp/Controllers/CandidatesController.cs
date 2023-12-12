using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace HRMSApp.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HrmsAppDbContext _db;
        public CandidatesController(IUnitOfWork unitOfWork, HrmsAppDbContext db)
        {
            _unitOfWork = unitOfWork; 
            _db = db;
        }
        public IActionResult Index()
        {
              return _unitOfWork.candidate.GetAll()!= null ?
                
            View(_unitOfWork.candidate.GetAll().ToList()) : Problem("Entity set 'HrmsAppDbContext.Candidates'  is null.");
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var candidateModel = _unitOfWork.candidate.Get(D => D.Id == id);

            if (candidateModel == null)
            {
                return NotFound();
            }

            return View(candidateModel);
        }
        public IActionResult Create()
        {
            var user = _db.tbl_StateMaster.Where(S => S.IsActive == true).Select(E => E.State).ToList();
            ViewBag.Department = user;

            //var Experience = _context.tbl_Experience.Select(E => E.Experience).ToList();
            //ViewBag.Experience = Experience;

            //var Jobrole = candidateRepo.GetAll().ToList();
            //ViewBag.Jobrole = Jobrole;

            //var Qualification = _context.tbl_Qualification.Select(Q => Q.Qualification).ToList();
            //ViewBag.Qualification = Qualification;

            var candidate = new Candidate
            {
                //Candidate = new Candidate(),
                CandidateExperience = new List<CandidateExperience> { new CandidateExperience() },
                CandidateEducation = new List<CandidateEducation> { new CandidateEducation() }
            };
            return View(candidate);
        }
        
        [HttpPost]
        public IActionResult Create(Candidate candidateModel)
        {

            //candidateModel.Candidate_Name ="Thalai";
            candidateModel.Candidate_Id = "Tha_123_00";

            if (ModelState.IsValid)
            {
                _unitOfWork.candidate.Add(candidateModel);
                _unitOfWork.Save();

                if (candidateModel.CandidateEducation != null)
                {
                    foreach (var education in candidateModel.CandidateEducation)
                    {
                        education.CandidateId = candidateModel.Id;
                        //candidateRepo.Add(education);
                    }
                }

                if (candidateModel.CandidateExperience != null)
                {
                    foreach (var experience in candidateModel.CandidateExperience)
                    {
                        experience.CandidateId = candidateModel.Id;
                        //candidateRepo.Add(experience);
                    }
                }

                TempData["success"] = "Candidate Added Successfully";

                return RedirectToAction(nameof(Index));
            }
            return View(candidateModel);
        }
        public IActionResult Input()
        {

            var viewModel = new Candidate
            {
                //Candidate = new Candidate(),
                CandidateExperience = new List<CandidateExperience> { new CandidateExperience() }
            };
            return View(viewModel);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var candidateModel = _unitOfWork.candidate.Get(E => E.Id == id);

            if (candidateModel == null)
            {
                return NotFound();
            }
            return View(candidateModel);
        }

        [HttpPost]
        public IActionResult Edit(int id,Candidate candidateModel)
        {
            if (id != candidateModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.candidate.Update(candidateModel);
                    _unitOfWork.Save();
                    TempData["warning"] = " Candidate Update Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (candidateModel.Id == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(candidateModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var candidateModel = _unitOfWork.candidate.Get(E => E.Id == id);

            if (candidateModel == null)
            {
                return NotFound();
            }

            return View(candidateModel);
        }

        // POST: CandidateModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //if (_context.Candidates == null)
            //{
            //    return Problem("Entity set 'HrmsAppDbContext.Candidates'  is null.");
            //}
            var candidateModel = _unitOfWork.candidate.Get(E => E.Id == id);

            if (candidateModel != null)
            {
                _unitOfWork.candidate.Remove(candidateModel);
            }
            
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //private bool CandidateModelExists(int id)
        //{
        //  return (_context.Candidates?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
