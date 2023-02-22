using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class StateController : Controller
    {
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;

        public StateController(IStateService stateService, ICountryService countryService)
        {
            this._stateService = stateService;
            this._countryService = countryService;
        }

        // GET: StateController
        public async Task<IActionResult> Index()
        {
            var states = await _stateService.GetAllAsync(x => x.Country);
            ViewData["CountryId"] = _countryService.Dropdown();
            return View(states);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection fc)
        {
            int countryId = Convert.ToInt32(fc["CountryId"]);
            List<State> states = await _stateService.GetAllAsync(x=>x.CountryId== countryId, x=>x.Country);
            ViewData["CountryId"] = _countryService.Dropdown();
            return View(states);
        }



        // GET: StateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateController/Create
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

        // GET: StateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StateController/Edit/5
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

        // GET: StateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StateController/Delete/5
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

        //[HttpPost]
        //public async Task<IActionResult> LoadData(int? country)
        //{
        //    var draw = Request.Form["draw"].FirstOrDefault();
        //    var start = Request.Form["start"].FirstOrDefault();
        //    var length = Request.Form["length"].FirstOrDefault();
        //    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //    var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        //    var searchValue = Request.Form["search[value]"].FirstOrDefault();
        //    int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //    int skip = start != null ? Convert.ToInt32(start) : 0;
        //    int recordsTotal = 0;
        //    List<State> stateData = await _stateService.GetAllAsync();
        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        stateData = stateData.Where(m => m.Name.Contains(searchValue)
        //                                    || m.Country.Name.Contains(searchValue)).ToList();
        //    }
        //    recordsTotal = stateData.Count();
        //    var data = stateData.Skip(skip).Take(pageSize).ToList();
        //    var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
        //    return Json(jsonData);
        //}
    }
}
