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
    public class DanceMoveController : Controller
    {
        private readonly MvcDanceContext _context;

        public DanceMoveController(MvcDanceContext context)
        {
            _context = context;
        }

        // GET: DanceMove
        public async Task<IActionResult> Index()
        {
            var mvcDanceContext = _context.DanceMove.Include(d => d.Syllabus).Include(d => d.Video);
            return View(await mvcDanceContext.ToListAsync());
        }

        // GET: DanceMove/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceMove = await _context.DanceMove
                .Include(d => d.Syllabus)
                .Include(d => d.Video)
                .FirstOrDefaultAsync(m => m.DanceMoveId == id);
            if (danceMove == null)
            {
                return NotFound();
            }

            return View(danceMove);
        }

        // GET: DanceMove/Create
        public IActionResult Create()
        {
            ViewData["SyllabusId"] = new SelectList(_context.Syllabus, "SyllabusId", "SyllabusId");
            ViewData["DanceVideoId"] = new SelectList(_context.DanceVideo, "DanceVideoId", "DanceVideoId");
            return View();
        }

        // POST: DanceMove/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanceMoveId,Name,DanceVideoId,SyllabusId")] DanceMove danceMove)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danceMove);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SyllabusId"] = new SelectList(_context.Syllabus, "SyllabusId", "SyllabusId", danceMove.SyllabusId);
            ViewData["DanceVideoId"] = new SelectList(_context.DanceVideo, "DanceVideoId", "DanceVideoId", danceMove.DanceVideoId);
            return View(danceMove);
        }

        // GET: DanceMove/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceMove = await _context.DanceMove.FindAsync(id);
            if (danceMove == null)
            {
                return NotFound();
            }
            ViewData["SyllabusId"] = new SelectList(_context.Syllabus, "SyllabusId", "SyllabusId", danceMove.SyllabusId);
            ViewData["DanceVideoId"] = new SelectList(_context.DanceVideo, "DanceVideoId", "DanceVideoId", danceMove.DanceVideoId);
            return View(danceMove);
        }

        // POST: DanceMove/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanceMoveId,Name,DanceVideoId,SyllabusId")] DanceMove danceMove)
        {
            if (id != danceMove.DanceMoveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danceMove);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanceMoveExists(danceMove.DanceMoveId))
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
            ViewData["SyllabusId"] = new SelectList(_context.Syllabus, "SyllabusId", "SyllabusId", danceMove.SyllabusId);
            ViewData["DanceVideoId"] = new SelectList(_context.DanceVideo, "DanceVideoId", "DanceVideoId", danceMove.DanceVideoId);
            return View(danceMove);
        }

        // GET: DanceMove/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceMove = await _context.DanceMove
                .Include(d => d.Syllabus)
                .Include(d => d.Video)
                .FirstOrDefaultAsync(m => m.DanceMoveId == id);
            if (danceMove == null)
            {
                return NotFound();
            }

            return View(danceMove);
        }

        // POST: DanceMove/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danceMove = await _context.DanceMove.FindAsync(id);
            _context.DanceMove.Remove(danceMove);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanceMoveExists(int id)
        {
            return _context.DanceMove.Any(e => e.DanceMoveId == id);
        }
    }
}
