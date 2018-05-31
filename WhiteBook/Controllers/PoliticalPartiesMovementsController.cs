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
    public class PoliticalPartiesMovementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliticalPartiesMovementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoliticalPartiesMovements
        public async Task<IActionResult> Index()
        {
            return View(await _context.PoliticalPartiesMovements.ToListAsync());
        }

        // GET: PoliticalPartiesMovements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicalPartiesMovement = await _context.PoliticalPartiesMovements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (politicalPartiesMovement == null)
            {
                return NotFound();
            }

            return View(politicalPartiesMovement);
        }

        // GET: PoliticalPartiesMovements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoliticalPartiesMovements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr")] PoliticalPartiesMovement politicalPartiesMovement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(politicalPartiesMovement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(politicalPartiesMovement);
        }

        // GET: PoliticalPartiesMovements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicalPartiesMovement = await _context.PoliticalPartiesMovements.SingleOrDefaultAsync(m => m.Id == id);
            if (politicalPartiesMovement == null)
            {
                return NotFound();
            }
            return View(politicalPartiesMovement);
        }

        // POST: PoliticalPartiesMovements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr")] PoliticalPartiesMovement politicalPartiesMovement)
        {
            if (id != politicalPartiesMovement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(politicalPartiesMovement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliticalPartiesMovementExists(politicalPartiesMovement.Id))
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
            return View(politicalPartiesMovement);
        }

        // GET: PoliticalPartiesMovements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicalPartiesMovement = await _context.PoliticalPartiesMovements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (politicalPartiesMovement == null)
            {
                return NotFound();
            }

            return View(politicalPartiesMovement);
        }

        // POST: PoliticalPartiesMovements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var politicalPartiesMovement = await _context.PoliticalPartiesMovements.SingleOrDefaultAsync(m => m.Id == id);
            _context.PoliticalPartiesMovements.Remove(politicalPartiesMovement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliticalPartiesMovementExists(int id)
        {
            return _context.PoliticalPartiesMovements.Any(e => e.Id == id);
        }
    }
}
