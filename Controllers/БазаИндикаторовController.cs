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
    public class БазаИндикаторовController : Controller
    {
        private readonly SopkaDbContext _context;

        public БазаИндикаторовController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: БазаИндикаторов
        public async Task<IActionResult> Index()
        {
            var sopkaDbContext = _context.БазаИндикаторов.Include(б => б.IdОбщегоИндикатораNavigation);
            return View(await sopkaDbContext.ToListAsync());
        }

        // GET: БазаИндикаторов/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var базаИндикаторов = await _context.БазаИндикаторов
                .Include(б => б.IdОбщегоИндикатораNavigation)
                .FirstOrDefaultAsync(m => m.IdИндикатора == id);
            if (базаИндикаторов == null)
            {
                return NotFound();
            }

            return View(базаИндикаторов);
        }

        // GET: БазаИндикаторов/Create
        public IActionResult Create()
        {
            ViewData["IdОбщегоИндикатора"] = new SelectList(_context.Индикаторы, "IdОбщегоИндикатора", "IdОбщегоИндикатора");
            return View();
        }

        // POST: БазаИндикаторов/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdИндикатора,IdОбщегоИндикатора,ДатаПервогоПоявления,ДатаПоследнегоПоявления")] БазаИндикаторов базаИндикаторов)
        {
            if (ModelState.IsValid)
            {
                _context.Add(базаИндикаторов);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdОбщегоИндикатора"] = new SelectList(_context.Индикаторы, "IdОбщегоИндикатора", "IdОбщегоИндикатора", базаИндикаторов.IdОбщегоИндикатора);
            return View(базаИндикаторов);
        }

        // GET: БазаИндикаторов/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var базаИндикаторов = await _context.БазаИндикаторов.FindAsync(id);
            if (базаИндикаторов == null)
            {
                return NotFound();
            }
            ViewData["IdОбщегоИндикатора"] = new SelectList(_context.Индикаторы, "IdОбщегоИндикатора", "IdОбщегоИндикатора", базаИндикаторов.IdОбщегоИндикатора);
            return View(базаИндикаторов);
        }

        // POST: БазаИндикаторов/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdИндикатора,IdОбщегоИндикатора,ДатаПервогоПоявления,ДатаПоследнегоПоявления")] БазаИндикаторов базаИндикаторов)
        {
            if (id != базаИндикаторов.IdИндикатора)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(базаИндикаторов);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!БазаИндикаторовExists(базаИндикаторов.IdИндикатора))
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
            ViewData["IdОбщегоИндикатора"] = new SelectList(_context.Индикаторы, "IdОбщегоИндикатора", "IdОбщегоИндикатора", базаИндикаторов.IdОбщегоИндикатора);
            return View(базаИндикаторов);
        }

        // GET: БазаИндикаторов/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var базаИндикаторов = await _context.БазаИндикаторов
                .Include(б => б.IdОбщегоИндикатораNavigation)
                .FirstOrDefaultAsync(m => m.IdИндикатора == id);
            if (базаИндикаторов == null)
            {
                return NotFound();
            }

            return View(базаИндикаторов);
        }

        // POST: БазаИндикаторов/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var базаИндикаторов = await _context.БазаИндикаторов.FindAsync(id);
            _context.БазаИндикаторов.Remove(базаИндикаторов);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool БазаИндикаторовExists(int id)
        {
            return _context.БазаИндикаторов.Any(e => e.IdИндикатора == id);
        }
    }
}
