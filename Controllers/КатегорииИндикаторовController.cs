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
    public class КатегорииИндикаторовController : Controller
    {
        private readonly SopkaDbContext _context;

        public КатегорииИндикаторовController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: КатегорииИндикаторов
        public async Task<IActionResult> Index()
        {
            return View(await _context.КатегорииИндикаторов.ToListAsync());
        }

        // GET: КатегорииИндикаторов/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var категорииИндикаторов = await _context.КатегорииИндикаторов
                .FirstOrDefaultAsync(m => m.IdКатегории == id);
            if (категорииИндикаторов == null)
            {
                return NotFound();
            }

            return View(категорииИндикаторов);
        }

        // GET: КатегорииИндикаторов/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: КатегорииИндикаторов/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdКатегории,КатегорияИндикатора")] КатегорииИндикаторов категорииИндикаторов)
        {
            if (ModelState.IsValid)
            {
                _context.Add(категорииИндикаторов);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(категорииИндикаторов);
        }

        // GET: КатегорииИндикаторов/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var категорииИндикаторов = await _context.КатегорииИндикаторов.FindAsync(id);
            if (категорииИндикаторов == null)
            {
                return NotFound();
            }
            return View(категорииИндикаторов);
        }

        // POST: КатегорииИндикаторов/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdКатегории,КатегорияИндикатора")] КатегорииИндикаторов категорииИндикаторов)
        {
            if (id != категорииИндикаторов.IdКатегории)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(категорииИндикаторов);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!КатегорииИндикаторовExists(категорииИндикаторов.IdКатегории))
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
            return View(категорииИндикаторов);
        }

        // GET: КатегорииИндикаторов/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var категорииИндикаторов = await _context.КатегорииИндикаторов
                .FirstOrDefaultAsync(m => m.IdКатегории == id);
            if (категорииИндикаторов == null)
            {
                return NotFound();
            }

            return View(категорииИндикаторов);
        }

        // POST: КатегорииИндикаторов/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var категорииИндикаторов = await _context.КатегорииИндикаторов.FindAsync(id);
            _context.КатегорииИндикаторов.Remove(категорииИндикаторов);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool КатегорииИндикаторовExists(byte id)
        {
            return _context.КатегорииИндикаторов.Any(e => e.IdКатегории == id);
        }
    }
}
