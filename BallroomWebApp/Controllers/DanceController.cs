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
    public class DanceController : Controller
    {
        private readonly MvcDanceContext _context;

        public DanceController(MvcDanceContext context)
        {
            _context = context;
        }

        // GET: Dance
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dance.ToListAsync());
        }

        // GET: Dance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dance = await _context.Dance
                .FirstOrDefaultAsync(m => m.DanceId == id);
            if (dance == null)
            {
                return NotFound();
            }

            return View(dance);
        }

        // GET: Dance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanceId,Name,Speed")] Dance dance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dance);
        }

        // GET: Dance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dance = await _context.Dance.FindAsync(id);
            if (dance == null)
            {
                return NotFound();
            }
            return View(dance);
        }

        // POST: Dance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanceId,Name,Speed")] Dance dance)
        {
            if (id != dance.DanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanceExists(dance.DanceId))
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
            return View(dance);
        }

        // GET: Dance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dance = await _context.Dance
                .FirstOrDefaultAsync(m => m.DanceId == id);
            if (dance == null)
            {
                return NotFound();
            }

            return View(dance);
        }

        // POST: Dance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dance = await _context.Dance.FindAsync(id);
            _context.Dance.Remove(dance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanceExists(int id)
        {
            return _context.Dance.Any(e => e.DanceId == id);
        }
    }
}
