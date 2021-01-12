using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers
{
    public class SellerController : Controller
    {

        private readonly SellerServices _SellerServices;
        private readonly DepartmentServices _DepartmentServices;

        public SellerController(SellerServices SellerServices, DepartmentServices DepartmentServices)
        {
            _SellerServices = SellerServices;
            _DepartmentServices = DepartmentServices;
        }

        public IActionResult Index()
        {
            var list = _SellerServices.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _DepartmentServices.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _SellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _SellerServices.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Delete(int id)
        {
            _SellerServices.Remove(id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _SellerServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

    }
}
