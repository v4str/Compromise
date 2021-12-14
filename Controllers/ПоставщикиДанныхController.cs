using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Compromise.Models;

namespace Compromise.Controllers
{
    public class ПоставщикиДанныхController : Controller
    {
        private readonly SopkaDbContext _context;

        public ПоставщикиДанныхController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: ПоставщикиДанных
        public async Task<IActionResult> Index()
        {
            return View(await _context.ПоставщикиДанных.ToListAsync());
        }

        // GET: ПоставщикиДанных/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var поставщикиДанных = await _context.ПоставщикиДанных
                .FirstOrDefaultAsync(m => m.IdПоставщика == id);
            if (поставщикиДанных == null)
            {
                return NotFound();
            }

            return View(поставщикиДанных);
        }

        // GET: ПоставщикиДанных/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ПоставщикиДанных/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdПоставщика,Поставщик,РейтингДоверия")] ПоставщикиДанных поставщикиДанных)
        {
            if (ModelState.IsValid)
            {
                _context.Add(поставщикиДанных);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(поставщикиДанных);
        }

        // GET: ПоставщикиДанных/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var поставщикиДанных = await _context.ПоставщикиДанных.FindAsync(id);
            if (поставщикиДанных == null)
            {
                return NotFound();
            }
            return View(поставщикиДанных);
        }

        // POST: ПоставщикиДанных/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdПоставщика,Поставщик,РейтингДоверия")] ПоставщикиДанных поставщикиДанных)
        {
            if (id != поставщикиДанных.IdПоставщика)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(поставщикиДанных);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ПоставщикиДанныхExists(поставщикиДанных.IdПоставщика))
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
            return View(поставщикиДанных);
        }

        // GET: ПоставщикиДанных/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var поставщикиДанных = await _context.ПоставщикиДанных
                .FirstOrDefaultAsync(m => m.IdПоставщика == id);
            if (поставщикиДанных == null)
            {
                return NotFound();
            }

            return View(поставщикиДанных);
        }

        // POST: ПоставщикиДанных/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var поставщикиДанных = await _context.ПоставщикиДанных.FindAsync(id);
            _context.ПоставщикиДанных.Remove(поставщикиДанных);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ПоставщикиДанныхExists(byte id)
        {
            return _context.ПоставщикиДанных.Any(e => e.IdПоставщика == id);
        }
    }
}
