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
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        private readonly ProductCategoryContext _productCategoryContext;

        public ProductsController(ProductContext context, ProductCategoryContext productCategoryContext)
        {
            _context = context;
            _productCategoryContext = productCategoryContext;
        }

        // GET: Products
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            List<ProductCatagory> productCatagories = _productCategoryContext.ProductCatagories.ToList();
            ViewBag.ProductCatagories = new SelectList(productCatagories, "CatagoryId", "CatagoryName");

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Price,Catagory,Info")] Product product)
        {
            if (ModelState.IsValid)
            {
                List<ProductCatagory> productCatagories = _productCategoryContext.ProductCatagories.ToList();

                foreach (ProductCatagory row in productCatagories)
                {
                    if (row.CatagoryId.ToString() == product.Catagory)
                    {
                        product.Catagory = row.CatagoryName;
                    }
                }
                
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            List<ProductCatagory> productCatagories = _productCategoryContext.ProductCatagories.ToList();
            ViewBag.ProductCatagories = new SelectList(productCatagories, "CatagoryId", "CatagoryName");

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Price,Catagory,Info")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    List<ProductCatagory> productCatagories = _productCategoryContext.ProductCatagories.ToList();

                    foreach (ProductCatagory row in productCatagories)
                    {
                        if (row.CatagoryId.ToString() == product.Catagory)
                        {
                            product.Catagory = row.CatagoryName;
                        }
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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

            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
