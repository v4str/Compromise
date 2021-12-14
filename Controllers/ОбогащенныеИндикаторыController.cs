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
    public class ОбогащенныеИндикаторыController : Controller
    {
        private readonly SopkaDbContext _context;

        public ОбогащенныеИндикаторыController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: ОбогащенныеИндикаторы
        public async Task<IActionResult> Index()
        {
            var sopkaDbContext = _context.ОбогащенныеИндикаторы.Include(о => о.IdОбщегоИндикатораNavigation);
            return View(await sopkaDbContext.ToListAsync());
        }

        // GET: ОбогащенныеИндикаторы/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var обогащенныеИндикаторы = await _context.ОбогащенныеИндикаторы
                .Include(о => о.IdОбщегоИндикатораNavigation)
                .FirstOrDefaultAsync(m => m.IdОбогащенногоИндикатора == id);
            if (обогащенныеИндикаторы == null)
            {
                return NotFound();
            }

            return View(обогащенныеИндикаторы);
        }

        // GET: ОбогащенныеИндикаторы/Create
        public IActionResult Create()
        {
            ViewData["IdОбщегоИндикатора"] = new SelectList(_context.Индикаторы, "IdОбщегоИндикатора", "IdОбщегоИндикатора");
            return View();
        }

        // POST: ОбогащенныеИндикаторы/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdОбогащенногоИндикатора,IdОбщегоИндикатора,РейтингИндикатора,ДатаИзменения")] ОбогащенныеИндикаторы обогащенныеИндикаторы)
        {
            if (ModelState.IsValid)
            {
                _context.Add(обогащенныеИндикаторы);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdОбщегоИндикатора"] = new SelectList(_context.Индикаторы, "IdОбщегоИндикатора", "IdОбщегоИндикатора", обогащенныеИндикаторы.IdОбщегоИндикатора);
            return View(обогащенныеИндикаторы);
        }

        // GET: ОбогащенныеИндикаторы/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var обогащенныеИндикаторы = await _context.ОбогащенныеИндикаторы.FindAsync(id);
            if (обогащенныеИндикаторы == null)
            {
                return NotFound();
            }
            ViewData["IdОбщегоИндикатора"] = new SelectList(_context.Индикаторы, "IdОбщегоИндикатора", "IdОбщегоИндикатора", обогащенныеИндикаторы.IdОбщегоИндикатора);
            return View(обогащенныеИндикаторы);
        }

        // POST: ОбогащенныеИндикаторы/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdОбогащенногоИндикатора,IdОбщегоИндикатора,РейтингИндикатора,ДатаИзменения")] ОбогащенныеИндикаторы обогащенныеИндикаторы)
        {
            if (id != обогащенныеИндикаторы.IdОбогащенногоИндикатора)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(обогащенныеИндикаторы);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ОбогащенныеИндикаторыExists(обогащенныеИндикаторы.IdОбогащенногоИндикатора))
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
            ViewData["IdОбщегоИндикатора"] = new SelectList(_context.Индикаторы, "IdОбщегоИндикатора", "IdОбщегоИндикатора", обогащенныеИндикаторы.IdОбщегоИндикатора);
            return View(обогащенныеИндикаторы);
        }

        // GET: ОбогащенныеИндикаторы/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var обогащенныеИндикаторы = await _context.ОбогащенныеИндикаторы
                .Include(о => о.IdОбщегоИндикатораNavigation)
                .FirstOrDefaultAsync(m => m.IdОбогащенногоИндикатора == id);
            if (обогащенныеИндикаторы == null)
            {
                return NotFound();
            }

            return View(обогащенныеИндикаторы);
        }

        // POST: ОбогащенныеИндикаторы/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var обогащенныеИндикаторы = await _context.ОбогащенныеИндикаторы.FindAsync(id);
            _context.ОбогащенныеИндикаторы.Remove(обогащенныеИндикаторы);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ОбогащенныеИндикаторыExists(int id)
        {
            return _context.ОбогащенныеИндикаторы.Any(e => e.IdОбогащенногоИндикатора == id);
        }
    }
}
