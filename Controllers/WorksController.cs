using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laba1.Models;

namespace laba1.Controllers
{
    public class WorksController : Controller
    {
        private readonly laba1Context _context;

        public WorksController(laba1Context context)
        {
            _context = context;
        }

        // GET: Works
        public async Task<IActionResult> Index()
        {
            var laba1Context = _context.Work.Include(w => w.Department);
            return View(await laba1Context.ToListAsync());
        }

        // GET: Works/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .Include(w => w.Department)
                .FirstOrDefaultAsync(m => m.WorkID == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // GET: Works/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (Department elem in _context.Department)
                {
                    if (elem.Name == model.DepartmentName)
                        model.DepartmentID = elem.DepartmentID;
                }

                if (model.DepartmentID == 0)
                {
                    ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name", model.DepartmentID);
                    return View();
                }

                Work work = new Work
                {
                    ClientName = model.ClientName,
                    ClientPhone = model.ClientPhone,
                    Payment = model.Payment,
                    Deadline = model.Deadline,
                    Description = model.Description,
                    DepartmentID = model.DepartmentID,
                    Department = model.Department
                };



                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction("details", new { id = work.WorkID });
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name", model.DepartmentID);
            return View();
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name", work.DepartmentID);
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkID,ClientName,ClientPhone,Payment,Deadline,Description,DepartmentID")] Work work)
        {
            if (id != work.WorkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(work);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExists(work.WorkID))
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
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name", work.DepartmentID);
            return View(work);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .Include(w => w.Department)
                .FirstOrDefaultAsync(m => m.WorkID == id);
            if (work == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name");
            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var work = await _context.Work.FindAsync(id);
            _context.Work.Remove(work);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExists(int id)
        {
            return _context.Work.Any(e => e.WorkID == id);
        }
    }
}
