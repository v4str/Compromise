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
    public class ОтчетыController : Controller
    {
        private readonly SopkaDbContext _context;

        public ОтчетыController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: Отчеты
        public async Task<IActionResult> Index()
        {
            var sopkaDbContext = _context.Отчеты.Include(о => о.Id).Include(о => о.IdСотрудникаNavigation);
            return View(await sopkaDbContext.ToListAsync());
        }

        // GET: Отчеты/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var отчеты = await _context.Отчеты
                .Include(о => о.Id)
                .Include(о => о.IdСотрудникаNavigation)
                .FirstOrDefaultAsync(m => m.IdОтчета == id);
            if (отчеты == null)
            {
                return NotFound();
            }

            return View(отчеты);
        }

        // GET: Отчеты/Create
        public IActionResult Create()
        {
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора");
            ViewData["IdСотрудника"] = new SelectList(_context.УполномоченныеСотрудники, "IdСотрудника", "IdСотрудника");
            return View();
        }

        // POST: Отчеты/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdОтчета,ДатаСоставленияОтчета,Результат,IdСотрудника,IdИндикатора,IdОбщегоИндикатора")] Отчеты отчеты)
        {
            if (ModelState.IsValid)
            {
                _context.Add(отчеты);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", отчеты.IdИндикатора);
            ViewData["IdСотрудника"] = new SelectList(_context.УполномоченныеСотрудники, "IdСотрудника", "IdСотрудника", отчеты.IdСотрудника);
            return View(отчеты);
        }

        // GET: Отчеты/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var отчеты = await _context.Отчеты.FindAsync(id);
            if (отчеты == null)
            {
                return NotFound();
            }
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", отчеты.IdИндикатора);
            ViewData["IdСотрудника"] = new SelectList(_context.УполномоченныеСотрудники, "IdСотрудника", "IdСотрудника", отчеты.IdСотрудника);
            return View(отчеты);
        }

        // POST: Отчеты/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IdОтчета,ДатаСоставленияОтчета,Результат,IdСотрудника,IdИндикатора,IdОбщегоИндикатора")] Отчеты отчеты)
        {
            if (id != отчеты.IdОтчета)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(отчеты);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ОтчетыExists(отчеты.IdОтчета))
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
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", отчеты.IdИндикатора);
            ViewData["IdСотрудника"] = new SelectList(_context.УполномоченныеСотрудники, "IdСотрудника", "IdСотрудника", отчеты.IdСотрудника);
            return View(отчеты);
        }

        // GET: Отчеты/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var отчеты = await _context.Отчеты
                .Include(о => о.Id)
                .Include(о => о.IdСотрудникаNavigation)
                .FirstOrDefaultAsync(m => m.IdОтчета == id);
            if (отчеты == null)
            {
                return NotFound();
            }

            return View(отчеты);
        }

        // POST: Отчеты/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var отчеты = await _context.Отчеты.FindAsync(id);
            _context.Отчеты.Remove(отчеты);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ОтчетыExists(short id)
        {
            return _context.Отчеты.Any(e => e.IdОтчета == id);
        }
    }
}
