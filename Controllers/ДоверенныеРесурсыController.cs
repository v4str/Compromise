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
    public class ДоверенныеРесурсыController : Controller
    {
        private readonly SopkaDbContext _context;

        public ДоверенныеРесурсыController(SopkaDbContext context)
        {
            _context = context;
        }

        // GET: ДоверенныеРесурсы
        public async Task<IActionResult> Index()
        {
            var sopkaDbContext = _context.ДоверенныеРесурсы.Include(д => д.Id);
            return View(await sopkaDbContext.ToListAsync());
        }

        // GET: ДоверенныеРесурсы/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var доверенныеРесурсы = await _context.ДоверенныеРесурсы
                .Include(д => д.Id)
                .FirstOrDefaultAsync(m => m.IdРесурса == id);
            if (доверенныеРесурсы == null)
            {
                return NotFound();
            }

            return View(доверенныеРесурсы);
        }

        // GET: ДоверенныеРесурсы/Create
        public IActionResult Create()
        {
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора");
            return View();
        }

        // POST: ДоверенныеРесурсы/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdРесурса,IpАдрес,НазваниеОрганизации,IdИндикатора,IdОбщегоИндикатора")] ДоверенныеРесурсы доверенныеРесурсы)
        {
            if (ModelState.IsValid)
            {
                _context.Add(доверенныеРесурсы);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", доверенныеРесурсы.IdИндикатора);
            return View(доверенныеРесурсы);
        }

        // GET: ДоверенныеРесурсы/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var доверенныеРесурсы = await _context.ДоверенныеРесурсы.FindAsync(id);
            if (доверенныеРесурсы == null)
            {
                return NotFound();
            }
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", доверенныеРесурсы.IdИндикатора);
            return View(доверенныеРесурсы);
        }

        // POST: ДоверенныеРесурсы/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdРесурса,IpАдрес,НазваниеОрганизации,IdИндикатора,IdОбщегоИндикатора")] ДоверенныеРесурсы доверенныеРесурсы)
        {
            if (id != доверенныеРесурсы.IdРесурса)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(доверенныеРесурсы);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ДоверенныеРесурсыExists(доверенныеРесурсы.IdРесурса))
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
            ViewData["IdИндикатора"] = new SelectList(_context.БазаИндикаторов, "IdИндикатора", "IdИндикатора", доверенныеРесурсы.IdИндикатора);
            return View(доверенныеРесурсы);
        }

        // GET: ДоверенныеРесурсы/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var доверенныеРесурсы = await _context.ДоверенныеРесурсы
                .Include(д => д.Id)
                .FirstOrDefaultAsync(m => m.IdРесурса == id);
            if (доверенныеРесурсы == null)
            {
                return NotFound();
            }

            return View(доверенныеРесурсы);
        }

        // POST: ДоверенныеРесурсы/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var доверенныеРесурсы = await _context.ДоверенныеРесурсы.FindAsync(id);
            _context.ДоверенныеРесурсы.Remove(доверенныеРесурсы);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ДоверенныеРесурсыExists(byte id)
        {
            return _context.ДоверенныеРесурсы.Any(e => e.IdРесурса == id);
        }
    }
}
