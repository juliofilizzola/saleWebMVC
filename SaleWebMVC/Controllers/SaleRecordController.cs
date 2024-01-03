using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Data;
using SaleWebMVC.Models;

namespace SaleWebMVC.Controllers
{
    public class SaleRecordController : Controller
    {
        private readonly SaleWebMvcContext _context;

        public SaleRecordController(SaleWebMvcContext context)
        {
            _context = context;
        }

        // GET: SaleRecord
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleRecord.ToListAsync());
        }

        // GET: SaleRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRecord = await _context.SaleRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleRecord == null)
            {
                return NotFound();
            }

            return View(saleRecord);
        }

        // GET: SaleRecord/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Status")] SaleRecord saleRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleRecord);
        }

        // GET: SaleRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRecord = await _context.SaleRecord.FindAsync(id);
            if (saleRecord == null)
            {
                return NotFound();
            }
            return View(saleRecord);
        }

        // POST: SaleRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,Status")] SaleRecord saleRecord)
        {
            if (id != saleRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleRecordExists(saleRecord.Id))
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
            return View(saleRecord);
        }

        // GET: SaleRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRecord = await _context.SaleRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleRecord == null)
            {
                return NotFound();
            }

            return View(saleRecord);
        }

        // POST: SaleRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleRecord = await _context.SaleRecord.FindAsync(id);
            if (saleRecord != null)
            {
                _context.SaleRecord.Remove(saleRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleRecordExists(int id)
        {
            return _context.SaleRecord.Any(e => e.Id == id);
        }
    }
}
