using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BallroomWebApp.Data;
using BallroomWebApp.Models;

namespace BallroomWebApp.Controllers
{
    public class SyllabusController : Controller
    {
        private readonly MvcDanceContext _context;

        public SyllabusController(MvcDanceContext context)
        {
            _context = context;
        }

        // GET: Syllabus
        public async Task<IActionResult> Index()
        {
            var mvcDanceContext = _context.Syllabus.Include(s => s.Dance);

            
            return View(await mvcDanceContext.ToListAsync());
        }

        // GET: Syllabus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabus
                .Include(s => s.Dance)
                .FirstOrDefaultAsync(m => m.SyllabusId == id);
            if (syllabus == null)
            {
                return NotFound();
            }

            return View(syllabus);
        }

        // GET: Syllabus/Create
        public IActionResult Create()
        {
            ViewData["DanceId"] = new SelectList(_context.Dance, "DanceId", "DanceId");
            return View();
        }

        // POST: Syllabus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SyllabusId,Level,DanceId")] Syllabus syllabus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(syllabus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanceId"] = new SelectList(_context.Dance, "DanceId", "DanceId", syllabus.DanceId);
            return View(syllabus);
        }

        // GET: Syllabus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabus.FindAsync(id);
            if (syllabus == null)
            {
                return NotFound();
            }
            ViewData["DanceId"] = new SelectList(_context.Dance, "DanceId", "DanceId", syllabus.DanceId);
            return View(syllabus);
        }

        // POST: Syllabus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SyllabusId,Level,DanceId")] Syllabus syllabus)
        {
            if (id != syllabus.SyllabusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(syllabus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SyllabusExists(syllabus.SyllabusId))
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
            ViewData["DanceId"] = new SelectList(_context.Dance, "DanceId", "DanceId", syllabus.DanceId);
            return View(syllabus);
        }

        // GET: Syllabus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabus
                .Include(s => s.Dance)
                .FirstOrDefaultAsync(m => m.SyllabusId == id);
            if (syllabus == null)
            {
                return NotFound();
            }

            return View(syllabus);
        }

        // POST: Syllabus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var syllabus = await _context.Syllabus.FindAsync(id);
            _context.Syllabus.Remove(syllabus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SyllabusExists(int id)
        {
            return _context.Syllabus.Any(e => e.SyllabusId == id);
        }
    }
}
