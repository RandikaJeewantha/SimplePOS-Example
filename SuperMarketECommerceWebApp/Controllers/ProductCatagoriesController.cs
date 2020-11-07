using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperMarketECommerceWebApp.Models;

namespace SuperMarketECommerceWebApp.Controllers
{
    public class ProductCatagoriesController : Controller
    {
        private readonly ProductCategoryContext _context;

        public ProductCatagoriesController(ProductCategoryContext context)
        {
            _context = context;
        }

        // GET: ProductCatagories
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(await _context.ProductCatagories.ToListAsync());
        }

        // GET: ProductCatagories/Details/5
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCatagory = await _context.ProductCatagories
                .FirstOrDefaultAsync(m => m.CatagoryId == id);
            if (productCatagory == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(productCatagory);
        }

        // GET: ProductCatagories/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View();
        }

        // POST: ProductCatagories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("CatagoryId,CatagoryName")] ProductCatagory productCatagory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCatagory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(productCatagory);
        }

        // GET: ProductCatagories/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCatagory = await _context.ProductCatagories.FindAsync(id);
            if (productCatagory == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(productCatagory);
        }

        // POST: ProductCatagories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("CatagoryId,CatagoryName")] ProductCatagory productCatagory)
        {
            if (id != productCatagory.CatagoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCatagory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCatagoryExists(productCatagory.CatagoryId))
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

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(productCatagory);
        }

        // GET: ProductCatagories/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCatagory = await _context.ProductCatagories
                .FirstOrDefaultAsync(m => m.CatagoryId == id);
            if (productCatagory == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(productCatagory);
        }

        // POST: ProductCatagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCatagory = await _context.ProductCatagories.FindAsync(id);
            _context.ProductCatagories.Remove(productCatagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCatagoryExists(int id)
        {
            return _context.ProductCatagories.Any(e => e.CatagoryId == id);
        }

    }
}
