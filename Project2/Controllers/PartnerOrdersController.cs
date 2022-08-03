using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;

namespace Project2.Controllers
{
    [Authorize]
    public class PartnerOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartnerOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: PartnerOrders
        public async Task<IActionResult> Index()
        {
              return _context.partnerOrders != null ? 
                          View(await _context.partnerOrders.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.partnerOrders'  is null.");
        }

        // GET: PartnerOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.partnerOrders == null)
            {
                return NotFound();
            }

            var partnerOrder = await _context.partnerOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnerOrder == null)
            {
                return NotFound();
            }

            return View(partnerOrder);
        }

        // GET: PartnerOrders/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: PartnerOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dept,TypeOfOreder,City,Duration,userid")] PartnerOrder partnerOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partnerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnerOrder);
        }

        // GET: PartnerOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.partnerOrders == null)
            {
                return NotFound();
            }

            var partnerOrder = await _context.partnerOrders.FindAsync(id);
            if (partnerOrder == null)
            {
                return NotFound();
            }
            return View(partnerOrder);
        }

        // POST: PartnerOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dept,TypeOfOreder,City,Duration,userid")] PartnerOrder partnerOrder)
        {
            if (id != partnerOrder.Id)
            {
                return NotFound();
            }
            ModelState.Remove("userid");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partnerOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerOrderExists(partnerOrder.Id))
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
            return View(partnerOrder);
        }

        public async Task<IActionResult> ManageOrder()
        {
            return View(await _context.partnerOrders.ToListAsync());
        }

        // GET: PartnerOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.partnerOrders == null)
            {
                return NotFound();
            }

            var partnerOrder = await _context.partnerOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnerOrder == null)
            {
                return NotFound();
            }

            return View(partnerOrder);
        }

        // POST: PartnerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.partnerOrders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.partnerOrders'  is null.");
            }
            var partnerOrder = await _context.partnerOrders.FindAsync(id);
            if (partnerOrder != null)
            {
                _context.partnerOrders.Remove(partnerOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerOrderExists(int id)
        {
          return (_context.partnerOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
