using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentRecords.Data;
using StudentRecords.Models;

namespace StudentRecords.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class UnitsController : Controller
    {
        private readonly RecordsContext _context;

        public UnitsController(RecordsContext context)
        {
            _context = context;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
            var recordsContext = _context.Units.Include(u => u.Results);
            return View(await recordsContext.ToListAsync());
        }

        // GET: Units/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Units
                .Include(u => u.Results)
                .FirstOrDefaultAsync(m => m.UnitCode == id);
            if (units == null)
            {
                return NotFound();
            }

            return View(units);
        }

        // GET: Units/Create
        public IActionResult Create()
        {
            ViewData["UnitCode"] = new SelectList(_context.Results, "StudentId", "StudentId");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitCode,UnitTitle,UnitCoordinator,UnitOutline")] Units units)
        {
            if (ModelState.IsValid)
            {
                _context.Add(units);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitCode"] = new SelectList(_context.Results, "StudentId", "StudentId", units.UnitCode);
            return View(units);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Units.FindAsync(id);
            if (units == null)
            {
                return NotFound();
            }
            ViewData["UnitCode"] = new SelectList(_context.Results, "StudentId", "StudentId", units.UnitCode);
            return View(units);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UnitCode,UnitTitle,UnitCoordinator,UnitOutline")] Units units)
        {
            if (id != units.UnitCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(units);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitsExists(units.UnitCode))
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
            ViewData["UnitCode"] = new SelectList(_context.Results, "StudentId", "StudentId", units.UnitCode);
            return View(units);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Units
                .Include(u => u.Results)
                .FirstOrDefaultAsync(m => m.UnitCode == id);
            if (units == null)
            {
                return NotFound();
            }

            return View(units);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var units = await _context.Units.FindAsync(id);
            _context.Units.Remove(units);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitsExists(string id)
        {
            return _context.Units.Any(e => e.UnitCode == id);
        }
    }
}
