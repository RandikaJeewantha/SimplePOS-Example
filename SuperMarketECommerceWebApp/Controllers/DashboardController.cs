using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SuperMarketECommerceWebApp.Models;

namespace SuperMarketECommerceWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly OrderContext _orderContext;
        private readonly ProductContext _productContext;
        private readonly ProductCategoryContext _productCategoryContext;

        public DashboardController(OrderContext ordercontext, ProductContext productContext, ProductCategoryContext productCategoryContext)
        {
            _orderContext = ordercontext;
            _productContext = productContext;
            _productCategoryContext = productCategoryContext;
        }

        [Authorize(Roles = "Admin, Cashier")]
        public IActionResult Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.email = HttpContext.Session.GetString("email");

            List<Order> Orders = _orderContext.Orders.OrderByDescending(a => a.OrderId).Take(5).ToList();
            ViewBag.Orders = Orders;

            ViewBag.CategoryCount = _productCategoryContext.ProductCatagories.Count();
            ViewBag.ProductCount = _productContext.Products.Count();

            ViewBag.OrderCountThisMonth = _orderContext.Orders.Count();

            ViewBag.RevenueCountThisMonth = _orderContext.Orders.Select(i => Convert.ToDecimal(i.OrderCost)).Sum();

            List<Order> jsdata = _orderContext.Orders.ToList();
            ViewBag.jsdata = jsdata;

            List<Product> product = _productContext.Products.ToList();
            ViewBag.Products = product;

            return View();
        }
    }
}
