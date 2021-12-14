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
    public class ИндикаторыController : Controller
    {
        private readonly SopkaDbContext _context;

        public ИндикаторыController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: Индикаторы
        public async Task<IActionResult> Index()
        {
            var sopkaDbContext = _context.Индикаторы.Include(и => и.IdКатегорииNavigation).Include(и => и.IdКритерияNavigation);
            return View(await sopkaDbContext.ToListAsync());
        }

        // GET: Индикаторы/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var индикаторы = await _context.Индикаторы
                .Include(и => и.IdКатегорииNavigation)
                .Include(и => и.IdКритерияNavigation)
                .FirstOrDefaultAsync(m => m.IdОбщегоИндикатора == id);
            if (индикаторы == null)
            {
                return NotFound();
            }

            return View(индикаторы);
        }

        // GET: Индикаторы/Create
        public IActionResult Create()
        {
            ViewData["IdКатегории"] = new SelectList(_context.КатегорииИндикаторов, "IdКатегории", "IdКатегории");
            ViewData["IdКритерия"] = new SelectList(_context.КритерииОценкиПолученныхРезультатов, "IdКритерия", "IdКритерия");
            return View();
        }

        // POST: Индикаторы/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Тип,Значение,Контекст,IdОбщегоИндикатора,IdКритерия,IdКатегории")] Индикаторы индикаторы)
        {
            if (ModelState.IsValid)
            {
                _context.Add(индикаторы);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdКатегории"] = new SelectList(_context.КатегорииИндикаторов, "IdКатегории", "IdКатегории", индикаторы.IdКатегории);
            ViewData["IdКритерия"] = new SelectList(_context.КритерииОценкиПолученныхРезультатов, "IdКритерия", "IdКритерия", индикаторы.IdКритерия);
            return View(индикаторы);
        }

        // GET: Индикаторы/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var индикаторы = await _context.Индикаторы.FindAsync(id);
            if (индикаторы == null)
            {
                return NotFound();
            }
            ViewData["IdКатегории"] = new SelectList(_context.КатегорииИндикаторов, "IdКатегории", "IdКатегории", индикаторы.IdКатегории);
            ViewData["IdКритерия"] = new SelectList(_context.КритерииОценкиПолученныхРезультатов, "IdКритерия", "IdКритерия", индикаторы.IdКритерия);
            return View(индикаторы);
        }

        // POST: Индикаторы/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Тип,Значение,Контекст,IdОбщегоИндикатора,IdКритерия,IdКатегории")] Индикаторы индикаторы)
        {
            if (id != индикаторы.IdОбщегоИндикатора)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(индикаторы);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ИндикаторыExists(индикаторы.IdОбщегоИндикатора))
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
            ViewData["IdКатегории"] = new SelectList(_context.КатегорииИндикаторов, "IdКатегории", "IdКатегории", индикаторы.IdКатегории);
            ViewData["IdКритерия"] = new SelectList(_context.КритерииОценкиПолученныхРезультатов, "IdКритерия", "IdКритерия", индикаторы.IdКритерия);
            return View(индикаторы);
        }

        // GET: Индикаторы/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var индикаторы = await _context.Индикаторы
                .Include(и => и.IdКатегорииNavigation)
                .Include(и => и.IdКритерияNavigation)
                .FirstOrDefaultAsync(m => m.IdОбщегоИндикатора == id);
            if (индикаторы == null)
            {
                return NotFound();
            }

            return View(индикаторы);
        }

        // POST: Индикаторы/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var индикаторы = await _context.Индикаторы.FindAsync(id);
            _context.Индикаторы.Remove(индикаторы);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ИндикаторыExists(int id)
        {
            return _context.Индикаторы.Any(e => e.IdОбщегоИндикатора == id);
        }
    }
}
