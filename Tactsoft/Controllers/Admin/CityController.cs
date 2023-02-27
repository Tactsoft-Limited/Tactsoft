using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
  
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;

        public CityController(ICityService cityService, IStateService stateService, ICountryService countryService)
        {
            this._cityService = cityService;
            this._stateService = stateService;
            this._countryService = countryService;
        }

        // GET: CityController
        public async Task<IActionResult> Index()
        {
            return View(await _cityService.GetAllAsync(e=>e.State));
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CityController/Delete/5
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

        // GET: CountryController/Create
        public IActionResult CreatePartial()
        {
            City city = new City();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            return PartialView("_CreatePartial", city);
        }

        // POST: CountryController/Create
        [HttpPost]
        public async Task<JsonResult> CreatePartial([FromBody] City city)
        {
            return Json(await _cityService.InsertAsync(city));

        }
    }
}
