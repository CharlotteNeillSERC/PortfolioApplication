using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioApplication.Data;
using PortfolioApplication.Models;

namespace PortfolioApplication.Controllers
{
    public class ContactInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactInfoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.ContactInfo.ToListAsync());
        }

        // GET: ContactInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,contactName,contactEmail,contactSubject,contactMessage")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactInfo);
        }

        
        private bool ContactInfoExists(int id)
        {
          return _context.ContactInfo.Any(e => e.Id == id);
        }
    }
}
