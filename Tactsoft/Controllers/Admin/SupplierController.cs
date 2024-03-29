﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        public SupplierController(ISupplierService supplierService, ICountryService countryService, 
            IStateService stateService, ICityService cityService)
        {
            _supplierService = supplierService;
            _countryService = countryService;
            _stateService = stateService;
            _cityService = cityService;
        }


        // GET: SupplierController
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllAsync(e => e.Country, e => e.State, e => e.City);
            return View(suppliers);
        }

        // GET: SupplierController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var supplier = await _supplierService.FindAsync(x=>x.Id==id, x=>x.Country,x=>x.State,x=>x.City);
            return View(supplier);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            Supplier supplier = new Supplier();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            return View(supplier);
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _supplierService.InsertAsync(supplier);

                }
                TempData["successAlert"] = "Supplier save successfull.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var supplier = await _supplierService.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            return View(supplier);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _supplierService.UpdateAsync(supplier);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
