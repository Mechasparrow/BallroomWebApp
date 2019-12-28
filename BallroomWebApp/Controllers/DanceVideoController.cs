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
    public class DanceVideoController : Controller
    {
        private readonly MvcDanceContext _context;

        public DanceVideoController(MvcDanceContext context)
        {
            _context = context;
        }

        // GET: DanceVideo
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanceVideo.ToListAsync());
        }

        // GET: DanceVideo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceVideo = await _context.DanceVideo
                .FirstOrDefaultAsync(m => m.DanceVideoId == id);
            if (danceVideo == null)
            {
                return NotFound();
            }

            return View(danceVideo);
        }

        // GET: DanceVideo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanceVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanceVideoId,Title,VideoUrl,Description")] DanceVideo danceVideo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danceVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danceVideo);
        }

        // GET: DanceVideo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceVideo = await _context.DanceVideo.FindAsync(id);
            if (danceVideo == null)
            {
                return NotFound();
            }
            return View(danceVideo);
        }

        // POST: DanceVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanceVideoId,Title,VideoUrl,Description")] DanceVideo danceVideo)
        {
            if (id != danceVideo.DanceVideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danceVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanceVideoExists(danceVideo.DanceVideoId))
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
            return View(danceVideo);
        }

        // GET: DanceVideo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceVideo = await _context.DanceVideo
                .FirstOrDefaultAsync(m => m.DanceVideoId == id);
            if (danceVideo == null)
            {
                return NotFound();
            }

            return View(danceVideo);
        }

        // POST: DanceVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danceVideo = await _context.DanceVideo.FindAsync(id);
            _context.DanceVideo.Remove(danceVideo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanceVideoExists(int id)
        {
            return _context.DanceVideo.Any(e => e.DanceVideoId == id);
        }
    }
}
