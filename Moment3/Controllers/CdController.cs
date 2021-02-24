using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moment3.Data;
using Moment3.Models;

namespace Moment3.Controllers
{
    public class CdController : Controller
    {
        private readonly DataContext _context;

        public CdController(DataContext context)
        {
            _context = context;
             _context.Database.EnsureCreated();
        }

        // GET: Cd
        public async Task<IActionResult> Index()
        {
            return View(await _context.CDs.ToListAsync());
        }

        // GET: Cd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CDs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // GET: Cd/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Year")] CD cD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cD);
        }

        // GET: Cd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CDs.FindAsync(id);
            if (cD == null)
            {
                return NotFound();
            }
            return View(cD);
        }

        // POST: Cd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year")] CD cD)
        {
            if (id != cD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CDExists(cD.Id))
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
            return View(cD);
        }

        // GET: Cd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CDs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // POST: Cd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cD = await _context.CDs.FindAsync(id);
            _context.CDs.Remove(cD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CDExists(int id)
        {
            return _context.CDs.Any(e => e.Id == id);
        }
    }
}
