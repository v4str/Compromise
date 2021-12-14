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
    public class КритерииОценкиПолученныхРезультатовController : Controller
    {
        private readonly SopkaDbContext _context;

        public КритерииОценкиПолученныхРезультатовController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: КритерииОценкиПолученныхРезультатов
        public async Task<IActionResult> Index()
        {
            var sopkaDbContext = _context.КритерииОценкиПолученныхРезультатов.Include(к => к.IdПоставщикаNavigation).Include(к => к.IdСтандартаNavigation);
            return View(await sopkaDbContext.ToListAsync());
        }

        // GET: КритерииОценкиПолученныхРезультатов/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var критерииОценкиПолученныхРезультатов = await _context.КритерииОценкиПолученныхРезультатов
                .Include(к => к.IdПоставщикаNavigation)
                .Include(к => к.IdСтандартаNavigation)
                .FirstOrDefaultAsync(m => m.IdКритерия == id);
            if (критерииОценкиПолученныхРезультатов == null)
            {
                return NotFound();
            }

            return View(критерииОценкиПолученныхРезультатов);
        }

        // GET: КритерииОценкиПолученныхРезультатов/Create
        public IActionResult Create()
        {
            ViewData["IdПоставщика"] = new SelectList(_context.ПоставщикиДанных, "IdПоставщика", "IdПоставщика");
            ViewData["IdСтандарта"] = new SelectList(_context.СтандартыОписанияДанных, "IdСтандарта", "IdСтандарта");
            return View();
        }

        // POST: КритерииОценкиПолученныхРезультатов/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdКритерия,ПолнотаКонтекста,IdСтандарта,IdПоставщика")] КритерииОценкиПолученныхРезультатов критерииОценкиПолученныхРезультатов)
        {
            if (ModelState.IsValid)
            {
                _context.Add(критерииОценкиПолученныхРезультатов);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdПоставщика"] = new SelectList(_context.ПоставщикиДанных, "IdПоставщика", "IdПоставщика", критерииОценкиПолученныхРезультатов.IdПоставщика);
            ViewData["IdСтандарта"] = new SelectList(_context.СтандартыОписанияДанных, "IdСтандарта", "IdСтандарта", критерииОценкиПолученныхРезультатов.IdСтандарта);
            return View(критерииОценкиПолученныхРезультатов);
        }

        // GET: КритерииОценкиПолученныхРезультатов/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var критерииОценкиПолученныхРезультатов = await _context.КритерииОценкиПолученныхРезультатов.FindAsync(id);
            if (критерииОценкиПолученныхРезультатов == null)
            {
                return NotFound();
            }
            ViewData["IdПоставщика"] = new SelectList(_context.ПоставщикиДанных, "IdПоставщика", "IdПоставщика", критерииОценкиПолученныхРезультатов.IdПоставщика);
            ViewData["IdСтандарта"] = new SelectList(_context.СтандартыОписанияДанных, "IdСтандарта", "IdСтандарта", критерииОценкиПолученныхРезультатов.IdСтандарта);
            return View(критерииОценкиПолученныхРезультатов);
        }

        // POST: КритерииОценкиПолученныхРезультатов/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdКритерия,ПолнотаКонтекста,IdСтандарта,IdПоставщика")] КритерииОценкиПолученныхРезультатов критерииОценкиПолученныхРезультатов)
        {
            if (id != критерииОценкиПолученныхРезультатов.IdКритерия)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(критерииОценкиПолученныхРезультатов);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!КритерииОценкиПолученныхРезультатовExists(критерииОценкиПолученныхРезультатов.IdКритерия))
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
            ViewData["IdПоставщика"] = new SelectList(_context.ПоставщикиДанных, "IdПоставщика", "IdПоставщика", критерииОценкиПолученныхРезультатов.IdПоставщика);
            ViewData["IdСтандарта"] = new SelectList(_context.СтандартыОписанияДанных, "IdСтандарта", "IdСтандарта", критерииОценкиПолученныхРезультатов.IdСтандарта);
            return View(критерииОценкиПолученныхРезультатов);
        }

        // GET: КритерииОценкиПолученныхРезультатов/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var критерииОценкиПолученныхРезультатов = await _context.КритерииОценкиПолученныхРезультатов
                .Include(к => к.IdПоставщикаNavigation)
                .Include(к => к.IdСтандартаNavigation)
                .FirstOrDefaultAsync(m => m.IdКритерия == id);
            if (критерииОценкиПолученныхРезультатов == null)
            {
                return NotFound();
            }

            return View(критерииОценкиПолученныхРезультатов);
        }

        // POST: КритерииОценкиПолученныхРезультатов/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var критерииОценкиПолученныхРезультатов = await _context.КритерииОценкиПолученныхРезультатов.FindAsync(id);
            _context.КритерииОценкиПолученныхРезультатов.Remove(критерииОценкиПолученныхРезультатов);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool КритерииОценкиПолученныхРезультатовExists(byte id)
        {
            return _context.КритерииОценкиПолученныхРезультатов.Any(e => e.IdКритерия == id);
        }
    }
}
