using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMSApp.Models;

namespace HRMSApp.Controllers
{
    public class CandidateModelsController : Controller
    {
        private readonly HrmsAppDbContext _context;

        public CandidateModelsController(HrmsAppDbContext context)
        {
            _context = context;
        }

        // GET: CandidateModels
        public async Task<IActionResult> Index()
        {
              return _context.Candidates != null ? 
                          View(await _context.Candidates.ToListAsync()) :
                          Problem("Entity set 'HrmsAppDbContext.Candidates'  is null.");
        }

        // GET: CandidateModels/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: CandidateModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CandidateModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Candidate_Name,Date_of_Brith,Email_Address,Mobile,Alternate_Mobile,Candidate_Address,Id_Proof,Qualifications,Experience,Department,Job_Role,Candidate_Id,interview_Date,Result")] CandidateModel candidateModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidateModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidateModel);
        }

        // GET: CandidateModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidateModel = await _context.Candidates.FindAsync(id);
            if (candidateModel == null)
            {
                return NotFound();
            }
            return View(candidateModel);
        }

        // POST: CandidateModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Candidate_Name,Date_of_Brith,Email_Address,Mobile,Alternate_Mobile,Candidate_Address,Id_Proof,Qualifications,Experience,Department,Job_Role,Candidate_Id,interview_Date,Result")] CandidateModel candidateModel)
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

        // GET: CandidateModels/Delete/5
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
