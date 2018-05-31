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
    public class CyberThreatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CyberThreatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CyberThreats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CyberThreats.Include(c => c.CountrySource).Include(c => c.CyberThreatType).Include(c => c.RadicalOrganization).Include(c => c.RiskyLevel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CyberThreats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyberThreat = await _context.CyberThreats
                .Include(c => c.CountrySource)
                .Include(c => c.CyberThreatType)
                .Include(c => c.RadicalOrganization)
                .Include(c => c.RiskyLevel)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cyberThreat == null)
            {
                return NotFound();
            }

            return View(cyberThreat);
        }

        // GET: CyberThreats/Create
        public IActionResult Create()
        {
            ViewData["CountrySourceId"] = new SelectList(_context.Countries, "Id", "Id");
            ViewData["CyberThreatTypeId"] = new SelectList(_context.CyberThreatTypes, "Id", "Id");
            ViewData["RadicalOrganizationId"] = new SelectList(_context.RadicalOrganizations, "Id", "Id");
            ViewData["RiskyLevelId"] = new SelectList(_context.RiskyLevels, "Id", "Id");
            return View();
        }

        // POST: CyberThreats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr,Date,RadicalOrganizationId,RiskyLevelId,CyberThreatTypeId,CountrySourceId")] CyberThreat cyberThreat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cyberThreat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountrySourceId"] = new SelectList(_context.Countries, "Id", "Id", cyberThreat.CountrySourceId);
            ViewData["CyberThreatTypeId"] = new SelectList(_context.CyberThreatTypes, "Id", "Id", cyberThreat.CyberThreatTypeId);
            ViewData["RadicalOrganizationId"] = new SelectList(_context.RadicalOrganizations, "Id", "Id", cyberThreat.RadicalOrganizationId);
            ViewData["RiskyLevelId"] = new SelectList(_context.RiskyLevels, "Id", "Id", cyberThreat.RiskyLevelId);
            return View(cyberThreat);
        }

        // GET: CyberThreats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyberThreat = await _context.CyberThreats.SingleOrDefaultAsync(m => m.Id == id);
            if (cyberThreat == null)
            {
                return NotFound();
            }
            ViewData["CountrySourceId"] = new SelectList(_context.Countries, "Id", "Id", cyberThreat.CountrySourceId);
            ViewData["CyberThreatTypeId"] = new SelectList(_context.CyberThreatTypes, "Id", "Id", cyberThreat.CyberThreatTypeId);
            ViewData["RadicalOrganizationId"] = new SelectList(_context.RadicalOrganizations, "Id", "Id", cyberThreat.RadicalOrganizationId);
            ViewData["RiskyLevelId"] = new SelectList(_context.RiskyLevels, "Id", "Id", cyberThreat.RiskyLevelId);
            return View(cyberThreat);
        }

        // POST: CyberThreats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr,Date,RadicalOrganizationId,RiskyLevelId,CyberThreatTypeId,CountrySourceId")] CyberThreat cyberThreat)
        {
            if (id != cyberThreat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cyberThreat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CyberThreatExists(cyberThreat.Id))
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
            ViewData["CountrySourceId"] = new SelectList(_context.Countries, "Id", "Id", cyberThreat.CountrySourceId);
            ViewData["CyberThreatTypeId"] = new SelectList(_context.CyberThreatTypes, "Id", "Id", cyberThreat.CyberThreatTypeId);
            ViewData["RadicalOrganizationId"] = new SelectList(_context.RadicalOrganizations, "Id", "Id", cyberThreat.RadicalOrganizationId);
            ViewData["RiskyLevelId"] = new SelectList(_context.RiskyLevels, "Id", "Id", cyberThreat.RiskyLevelId);
            return View(cyberThreat);
        }

        // GET: CyberThreats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyberThreat = await _context.CyberThreats
                .Include(c => c.CountrySource)
                .Include(c => c.CyberThreatType)
                .Include(c => c.RadicalOrganization)
                .Include(c => c.RiskyLevel)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cyberThreat == null)
            {
                return NotFound();
            }

            return View(cyberThreat);
        }

        // POST: CyberThreats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cyberThreat = await _context.CyberThreats.SingleOrDefaultAsync(m => m.Id == id);
            _context.CyberThreats.Remove(cyberThreat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CyberThreatExists(int id)
        {
            return _context.CyberThreats.Any(e => e.Id == id);
        }
    }
}
