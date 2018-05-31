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
    public class CyberThreatTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CyberThreatTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CyberThreatTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CyberThreatTypes.ToListAsync());
        }

        // GET: CyberThreatTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyberThreatType = await _context.CyberThreatTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cyberThreatType == null)
            {
                return NotFound();
            }

            return View(cyberThreatType);
        }

        // GET: CyberThreatTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CyberThreatTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr")] CyberThreatType cyberThreatType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cyberThreatType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cyberThreatType);
        }

        // GET: CyberThreatTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyberThreatType = await _context.CyberThreatTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (cyberThreatType == null)
            {
                return NotFound();
            }
            return View(cyberThreatType);
        }

        // POST: CyberThreatTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr")] CyberThreatType cyberThreatType)
        {
            if (id != cyberThreatType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cyberThreatType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CyberThreatTypeExists(cyberThreatType.Id))
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
            return View(cyberThreatType);
        }

        // GET: CyberThreatTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyberThreatType = await _context.CyberThreatTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cyberThreatType == null)
            {
                return NotFound();
            }

            return View(cyberThreatType);
        }

        // POST: CyberThreatTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cyberThreatType = await _context.CyberThreatTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.CyberThreatTypes.Remove(cyberThreatType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CyberThreatTypeExists(int id)
        {
            return _context.CyberThreatTypes.Any(e => e.Id == id);
        }
    }
}
