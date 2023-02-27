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

        // GET: CountryController/Create
        public IActionResult CreatePartial()
        {
            State state = new  State();
            ViewData["CountryId"] = _countryService.Dropdown();
            return PartialView("_CreatePartial", state);
        }

        // POST: CountryController/Create
        [HttpPost]
        public async Task<JsonResult> CreatePartial([FromBody] State state)
        {
            return Json(await _stateService.InsertAsync(state));

        }

        
    }
}
