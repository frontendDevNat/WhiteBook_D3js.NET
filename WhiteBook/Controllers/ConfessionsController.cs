using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteBook.Models;

namespace WhiteBook.Controllers
{
    public class ConfessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Confessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Confessions.Include(c => c.Religion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Confessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confession = await _context.Confessions
                .Include(c => c.Religion)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (confession == null)
            {
                return NotFound();
            }

            return View(confession);
        }

        // GET: Confessions/Create
        public IActionResult Create()
        {
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Descr");
            return View();
        }

        // POST: Confessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr,ReligionId")] Confession confession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Descr", confession.ReligionId);
            return View(confession);
        }

        // GET: Confessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confession = await _context.Confessions.SingleOrDefaultAsync(m => m.Id == id);
            if (confession == null)
            {
                return NotFound();
            }
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Descr", confession.ReligionId);
            return View(confession);
        }

        // POST: Confessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr,ReligionId")] Confession confession)
        {
            if (id != confession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfessionExists(confession.Id))
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
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Descr", confession.ReligionId);
            return View(confession);
        }

        // GET: Confessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confession = await _context.Confessions
                .Include(c => c.Religion)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (confession == null)
            {
                return NotFound();
            }

            return View(confession);
        }

        // POST: Confessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confession = await _context.Confessions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Confessions.Remove(confession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfessionExists(int id)
        {
            return _context.Confessions.Any(e => e.Id == id);
        }
    }
}
