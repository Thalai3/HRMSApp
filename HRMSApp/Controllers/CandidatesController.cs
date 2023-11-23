using HRMS.DataAccess.Data;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace HRMSApp.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly HrmsAppDbContext _context;

        public CandidatesController(HrmsAppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
              return _context.Candidates != null ? 
              View( _context.Candidates.ToList()) : Problem("Entity set 'HrmsAppDbContext.Candidates'  is null.");
        }
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidateModel =_context.Candidates
                .FirstOrDefault(m => m.Id == id);
            if (candidateModel == null)
            {
                return NotFound();
            }

            return View(candidateModel);
        }
        public IActionResult Create()
        {
            var Department = _context.tbl_Department.Select(D => D.Department).ToList(); 
            ViewBag.Department = Department;  

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
            //candidateModel.Candidate_Id = "Tha_123_00";

            if (ModelState.IsValid)
            {
                _context.Add(candidateModel);
                _context.SaveChanges();

                if(candidateModel.CandidateEducation != null)
                {
                    foreach (var education in candidateModel.CandidateEducation)
                    {
                        education.CandidateId = candidateModel.Id;
                        _context.tbl_CandidateQualification.Add(education);
                    }
                }

                if (candidateModel.CandidateExperience != null)
                {
                    foreach (var experience in candidateModel.CandidateExperience)
                    {
                        experience.CandidateId = candidateModel.Id;
                        _context.tbl_CandidateExperience.Add(experience);
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
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidateModel = _context.Candidates.Find(id);
            if (candidateModel == null)
            {
                return NotFound();
            }
            return View(candidateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Candidate candidateModel)
        {
            if (id != candidateModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidateModel);
                    await _context.SaveChangesAsync();
                    TempData["warning"] = " Candidate Update Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateModelExists(candidateModel.Id))
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidateModel = await _context.Candidates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidateModel == null)
            {
                return NotFound();
            }

            return View(candidateModel);
        }

        // POST: CandidateModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidates == null)
            {
                return Problem("Entity set 'HrmsAppDbContext.Candidates'  is null.");
            }
            var candidateModel = await _context.Candidates.FindAsync(id);
            if (candidateModel != null)
            {
                _context.Candidates.Remove(candidateModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateModelExists(int id)
        {
          return (_context.Candidates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
