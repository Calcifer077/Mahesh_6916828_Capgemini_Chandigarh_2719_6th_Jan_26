using ECommerceApp.Data;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShippingDetailsController : Controller
    {
        private readonly ECommerceAppContext _context;

        public ShippingDetailsController(ECommerceAppContext context)
        {
            _context = context;
        }

        // GET: ShippingDetails
        public async Task<IActionResult> Index()
        {
            var eCommerceAppContext = _context.ShippingDetail.Include(s => s.Order);
            return View(await eCommerceAppContext.ToListAsync());
        }

        // GET: ShippingDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingDetail = await _context.ShippingDetail
                .Include(s => s.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shippingDetail == null)
            {
                return NotFound();
            }

            return View(shippingDetail);
        }

        // GET: ShippingDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            return View();
        }

        // POST: ShippingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,Status,OrderId")] ShippingDetail shippingDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shippingDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", shippingDetail.OrderId);
            return View(shippingDetail);
        }

        // GET: ShippingDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingDetail = await _context.ShippingDetail.FindAsync(id);
            if (shippingDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", shippingDetail.OrderId);
            return View(shippingDetail);
        }

        // POST: ShippingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,Status,OrderId")] ShippingDetail shippingDetail)
        {
            if (id != shippingDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shippingDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingDetailExists(shippingDetail.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", shippingDetail.OrderId);
            return View(shippingDetail);
        }

        // GET: ShippingDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingDetail = await _context.ShippingDetail
                .Include(s => s.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shippingDetail == null)
            {
                return NotFound();
            }

            return View(shippingDetail);
        }

        // POST: ShippingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shippingDetail = await _context.ShippingDetail.FindAsync(id);
            if (shippingDetail != null)
            {
                _context.ShippingDetail.Remove(shippingDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingDetailExists(int id)
        {
            return _context.ShippingDetail.Any(e => e.Id == id);
        }
    }
}
