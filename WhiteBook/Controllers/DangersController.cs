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
    public class DangersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dangers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dangers.ToListAsync());
        }

        // GET: Dangers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danger = await _context.Dangers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (danger == null)
            {
                return NotFound();
            }

            return View(danger);
        }

        // GET: Dangers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dangers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr,Variable")] Danger danger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danger);
        }

        // GET: Dangers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danger = await _context.Dangers.SingleOrDefaultAsync(m => m.Id == id);
            if (danger == null)
            {
                return NotFound();
            }
            return View(danger);
        }

        // POST: Dangers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr,Variable")] Danger danger)
        {
            if (id != danger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangerExists(danger.Id))
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
            return View(danger);
        }

        // GET: Dangers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danger = await _context.Dangers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (danger == null)
            {
                return NotFound();
            }

            return View(danger);
        }

        // POST: Dangers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danger = await _context.Dangers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Dangers.Remove(danger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangerExists(int id)
        {
            return _context.Dangers.Any(e => e.Id == id);
        }
    }
}
