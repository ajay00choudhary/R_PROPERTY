using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using R_PROPERTY.Data;
using R_PROPERTY.Models;

namespace R_PROPERTY.Controllers
{
    public class property_detailsController : Controller
    {
        private readonly R_PROPERTY_DB_Context _context;

        public property_detailsController(R_PROPERTY_DB_Context context)
        {
            _context = context;
        }

        // GET: property_details
        public async Task<IActionResult> Index()
        {
            return View(await _context.property_details.ToListAsync());
        }

        // GET: property_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_details = await _context.property_details
                .FirstOrDefaultAsync(m => m.property_id == id);
            if (property_details == null)
            {
                return NotFound();
            }

            return View(property_details);
        }
         [Authorize]
        // GET: property_details/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: property_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("property_id,property_name,property_type,property_address,property_value")] property_details property_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(property_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(property_details);
        }
        [Authorize]
        // GET: property_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_details = await _context.property_details.FindAsync(id);
            if (property_details == null)
            {
                return NotFound();
            }
            return View(property_details);
        }
        [Authorize]
        // POST: property_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("property_id,property_name,property_type,property_address,property_value")] property_details property_details)
        {
            if (id != property_details.property_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(property_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!property_detailsExists(property_details.property_id))
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
            return View(property_details);
        }
        [Authorize]
        // GET: property_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_details = await _context.property_details
                .FirstOrDefaultAsync(m => m.property_id == id);
            if (property_details == null)
            {
                return NotFound();
            }

            return View(property_details);
        }
        [Authorize]
        // POST: property_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var property_details = await _context.property_details.FindAsync(id);
            _context.property_details.Remove(property_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool property_detailsExists(int id)
        {
            return _context.property_details.Any(e => e.property_id == id);
        }
    }
}
