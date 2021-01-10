using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellerController : Controller
    {

        private SellerServices _SellerServices;

        public SellerController(SellerServices sellerServices)
        {
            _SellerServices = sellerServices;
        }

        public IActionResult Index()
        {
            var list = _SellerServices.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller obj)
        {
            _SellerServices.Insert(obj);
            return RedirectToAction(nameof(Index));
        }
    }
}