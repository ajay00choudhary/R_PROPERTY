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
    public class inquiriesController : Controller
    {
        private readonly R_PROPERTY_DB_Context _context;

        public inquiriesController(R_PROPERTY_DB_Context context)
        {
            _context = context;
        }
        
        // GET: inquiries
        public async Task<IActionResult> Index()
        {
            return View(await _context.inquiry.ToListAsync());
        }

        // GET: inquiries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiry = await _context.inquiry
                .FirstOrDefaultAsync(m => m.inquiry_id == id);
            if (inquiry == null)
            {
                return NotFound();
            }

            return View(inquiry);
        }
        [Authorize]
        // GET: inquiries/Create
        public IActionResult Create()
        {
            return View();
        }
        //added the authorise option
        [Authorize]
        // POST: inquiries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("inquiry_id,user_id,property_id,user_massege,dateTime_inquiry")] inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquiry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inquiry);
        }
        [Authorize]
        // GET: inquiries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiry = await _context.inquiry.FindAsync(id);
            if (inquiry == null)
            {
                return NotFound();
            }
            return View(inquiry);
        }
        [Authorize]
        // POST: inquiries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("inquiry_id,user_id,property_id,user_massege,dateTime_inquiry")] inquiry inquiry)
        {
            if (id != inquiry.inquiry_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquiry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!inquiryExists(inquiry.inquiry_id))
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
            return View(inquiry);
        }
        [Authorize]
        // GET: inquiries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiry = await _context.inquiry
                .FirstOrDefaultAsync(m => m.inquiry_id == id);
            if (inquiry == null)
            {
                return NotFound();
            }

            return View(inquiry);
        }
        [Authorize]
        // POST: inquiries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inquiry = await _context.inquiry.FindAsync(id);
            _context.inquiry.Remove(inquiry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool inquiryExists(int id)
        {
            return _context.inquiry.Any(e => e.inquiry_id == id);
        }
    }
}
