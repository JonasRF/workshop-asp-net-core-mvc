using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}