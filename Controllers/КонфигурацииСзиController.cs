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
    public class КонфигурацииСзиController : Controller
    {
        private readonly SopkaDbContext _context;

        public КонфигурацииСзиController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: КонфигурацииСзи
        public async Task<IActionResult> Index()
        {
            var sopkaDbContext = _context.КонфигурацииСзи.Include(к => к.Id);
            return View(await sopkaDbContext.ToListAsync());
        }

        // GET: КонфигурацииСзи/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var конфигурацииСзи = await _context.КонфигурацииСзи
                .Include(к => к.Id)
                .FirstOrDefaultAsync(m => m.IdОповещения == id);
            if (конфигурацииСзи == null)
            {
                return NotFound();
            }

            return View(конфигурацииСзи);
        }

        // GET: КонфигурацииСзи/Create
        public IActionResult Create()
        {
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора");
            return View();
        }

        // POST: КонфигурацииСзи/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdОповещения,ОписаниеОповещения,УровеньОпасности,IdИндикатора,IdОбщегоИндикатора")] КонфигурацииСзи конфигурацииСзи)
        {
            if (ModelState.IsValid)
            {
                _context.Add(конфигурацииСзи);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", конфигурацииСзи.IdИндикатора);
            return View(конфигурацииСзи);
        }

        // GET: КонфигурацииСзи/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var конфигурацииСзи = await _context.КонфигурацииСзи.FindAsync(id);
            if (конфигурацииСзи == null)
            {
                return NotFound();
            }
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", конфигурацииСзи.IdИндикатора);
            return View(конфигурацииСзи);
        }

        // POST: КонфигурацииСзи/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdОповещения,ОписаниеОповещения,УровеньОпасности,IdИндикатора,IdОбщегоИндикатора")] КонфигурацииСзи конфигурацииСзи)
        {
            if (id != конфигурацииСзи.IdОповещения)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(конфигурацииСзи);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!КонфигурацииСзиExists(конфигурацииСзи.IdОповещения))
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
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", конфигурацииСзи.IdИндикатора);
            return View(конфигурацииСзи);
        }

        // GET: КонфигурацииСзи/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var конфигурацииСзи = await _context.КонфигурацииСзи
                .Include(к => к.Id)
                .FirstOrDefaultAsync(m => m.IdОповещения == id);
            if (конфигурацииСзи == null)
            {
                return NotFound();
            }

            return View(конфигурацииСзи);
        }

        // POST: КонфигурацииСзи/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var конфигурацииСзи = await _context.КонфигурацииСзи.FindAsync(id);
            _context.КонфигурацииСзи.Remove(конфигурацииСзи);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool КонфигурацииСзиExists(int id)
        {
            return _context.КонфигурацииСзи.Any(e => e.IdОповещения == id);
        }
    }
}
