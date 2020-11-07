using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperMarketECommerceWebApp.Models;

namespace SuperMarketECommerceWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: Users
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = User.Claims.FirstOrDefault(c => c.Type == "role").Value;
            if (id != HttpContext.Session.GetInt32("id") && claim != "Admin")
            {
                return NotFound();
            }

            var account = await _context.Users
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(account);
        }

        // GET: Users/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("AccountId,SecondName,FirstName,Gender,Position,Email,Password,PhoneNumber,ContactAddress,DateOfBirth")] User account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(account);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = User.Claims.FirstOrDefault(c => c.Type == "role").Value;
            if (id != HttpContext.Session.GetInt32("id") && claim != "Admin")
            {
                return NotFound();
            }

            var account = await _context.Users.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(account);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Cashier")]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,SecondName,FirstName,Gender,Position,Email,Password,PhoneNumber,ContactAddress,DateOfBirth")] User account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            var claim = User.Claims.FirstOrDefault(c => c.Type == "role").Value;
            if (id != HttpContext.Session.GetInt32("id") && claim != "Admin")
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Users/Details/"+id);
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(account);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Users
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            return View(account);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Users.FindAsync(id);
            _context.Users.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Users.Any(e => e.AccountId == id);
        }
    }
}
