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
    public class OrdersController : Controller
    {
        private readonly OrderContext _context;
        private readonly ProductContext _productContext;

        public OrdersController(OrderContext context, ProductContext productContext)
        {
            _context = context;
            _productContext = productContext;
        }

        // GET: Orders
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(order);
        }

        // GET: Orders/Create
        [Authorize(Roles = "Admin, Cashier")]
        public IActionResult Create()
        {
            List<Product> product = _productContext.Products.ToList();
            ViewBag.Products = product;

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Create([Bind("OrderId,Employee,CustomerName,PhoneNumber,Gender,Items,OrderCost,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<Product> product = _productContext.Products.ToList();
            ViewBag.Products = product;

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(order);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Employee,CustomerName,PhoneNumber,Gender,Items,OrderCost,Date")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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

            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
