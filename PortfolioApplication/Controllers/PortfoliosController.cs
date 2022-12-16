using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioApplication.Data;
using PortfolioApplication.Models;

namespace PortfolioApplication.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PortfoliosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Portfolios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Portfolio.ToListAsync());
        }

        // GET: Portfolios/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Portfolios/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Portfolio.Where(j => j.ProjectName.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Portfolio == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // GET: Portfolios/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,ProjectDescription")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolio);
        }

        // GET: Portfolios/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Portfolio == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolio.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,ProjectDescription")] Portfolio portfolio)
        {
            if (id != portfolio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.Id))
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
            return View(portfolio);
        }

        // GET: Portfolios/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Portfolio == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Portfolio == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Portfolio'  is null.");
            }
            var portfolio = await _context.Portfolio.FindAsync(id);
            if (portfolio != null)
            {
                _context.Portfolio.Remove(portfolio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioExists(int id)
        {
          return _context.Portfolio.Any(e => e.Id == id);
        }
    }
}
