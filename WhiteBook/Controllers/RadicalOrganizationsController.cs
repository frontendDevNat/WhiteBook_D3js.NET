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
    public class RadicalOrganizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RadicalOrganizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RadicalOrganizations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RadicalOrganizations.Include(r => r.PoliticalPartiesMovement).Include(r => r.Religion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RadicalOrganizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radicalOrganization = await _context.RadicalOrganizations
                .Include(r => r.PoliticalPartiesMovement)
                .Include(r => r.Religion)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (radicalOrganization == null)
            {
                return NotFound();
            }

            return View(radicalOrganization);
        }

        // GET: RadicalOrganizations/Create
        public IActionResult Create()
        {
            ViewData["PoliticalPartiesMovementId"] = new SelectList(_context.PoliticalPartiesMovements, "Id", "Descr");
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Descr");
            return View();
        }

        // POST: RadicalOrganizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr,ReligionId,PoliticalPartiesMovementId")] RadicalOrganization radicalOrganization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(radicalOrganization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoliticalPartiesMovementId"] = new SelectList(_context.PoliticalPartiesMovements, "Id", "Descr", radicalOrganization.PoliticalPartiesMovementId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Descr", radicalOrganization.ReligionId);
            return View(radicalOrganization);
        }

        // GET: RadicalOrganizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radicalOrganization = await _context.RadicalOrganizations.SingleOrDefaultAsync(m => m.Id == id);
            if (radicalOrganization == null)
            {
                return NotFound();
            }
            ViewData["PoliticalPartiesMovementId"] = new SelectList(_context.PoliticalPartiesMovements, "Id", "Descr", radicalOrganization.PoliticalPartiesMovementId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Descr", radicalOrganization.ReligionId);
            return View(radicalOrganization);
        }

        // POST: RadicalOrganizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr,ReligionId,PoliticalPartiesMovementId")] RadicalOrganization radicalOrganization)
        {
            if (id != radicalOrganization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(radicalOrganization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RadicalOrganizationExists(radicalOrganization.Id))
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
            ViewData["PoliticalPartiesMovementId"] = new SelectList(_context.PoliticalPartiesMovements, "Id", "Descr", radicalOrganization.PoliticalPartiesMovementId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Descr", radicalOrganization.ReligionId);
            return View(radicalOrganization);
        }

        // GET: RadicalOrganizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radicalOrganization = await _context.RadicalOrganizations
                .Include(r => r.PoliticalPartiesMovement)
                .Include(r => r.Religion)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (radicalOrganization == null)
            {
                return NotFound();
            }

            return View(radicalOrganization);
        }

        // POST: RadicalOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var radicalOrganization = await _context.RadicalOrganizations.SingleOrDefaultAsync(m => m.Id == id);
            _context.RadicalOrganizations.Remove(radicalOrganization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RadicalOrganizationExists(int id)
        {
            return _context.RadicalOrganizations.Any(e => e.Id == id);
        }
    }
}
