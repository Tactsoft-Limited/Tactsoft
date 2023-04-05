using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            this._itemService = itemService;
        }

        // GET: ItemController
        public async Task<IActionResult> Index()
        {
            return View( await _itemService.GetAllAsync());
        }

        // GET: ItemController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var data = await _itemService.FindAsync(id);
            return View(data);
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _itemService.InsertAsync(item);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _itemService.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _itemService.UpdateAsync(item);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemController/Delete/5
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
