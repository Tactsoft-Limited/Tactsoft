using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly ISupplierService _supplierService;
        private readonly IItemService _itemService;

        public PurchaseController(IPurchaseService purchaseService, ISupplierService supplierService,
            IItemService itemService) 
        {
            this._purchaseService = purchaseService;
            this._supplierService = supplierService;
            this._itemService = itemService;
        }

        // GET: PurchaseController
        public async Task<IActionResult> Index()
        {
            return View(await _purchaseService.GetAllAsync(i=>i.Supplier));
        }

        // GET: PurchaseController/Details/5
        public IActionResult Details(int id)
        {
            Purchase purchase = _purchaseService.GetItems(id);
            ViewData["SupplierId"] = _supplierService.Dropdown();
            ViewData["ItemId"] = _itemService.Dropdown();

            return View(purchase);
        }

        // GET: PurchaseController/Create
        public IActionResult Create()
        {
            ViewData["SupplierId"] = _supplierService.Dropdown();
            ViewData["ItemId"] = _itemService.Dropdown();
            Purchase purchase = new Purchase();
            purchase.PurchaseItems.Add(new PurchaseItem() { Id = 1 });
            return View(purchase);
        }

        // POST: PurchaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Purchase purchase)
        {
            if (!ModelState.IsValid && purchase.SupplierId == 0)
                return View(purchase);

            purchase.PurchaseItems.RemoveAll(x => x.Quantity == 0);

            await _purchaseService.InsertAsync(purchase);
            return RedirectToAction(nameof(Index));
        }

        // GET: PurchaseController/Edit/5
        public IActionResult Edit(int id)
        {
            Purchase purchase = _purchaseService.GetItems(id);

            ViewData["SupplierId"] = _supplierService.Dropdown();
            ViewData["ItemId"] = _itemService.Dropdown();

            return View(purchase);
        }

        // POST: PurchaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Purchase purchase)
        {
            purchase.PurchaseItems.RemoveAll(x => x.Quantity == 0);

            try
            {   
                await _purchaseService.UpdateRangeAsync(purchase);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseController/Delete/5
        public  IActionResult Delete(int id)
        {
            Purchase purchase = _purchaseService.GetItems(id);
            ViewData["SupplierId"] = _supplierService.Dropdown();
            ViewData["ItemId"] = _itemService.Dropdown();
            
            return View(purchase);
        }

        // POST: PurchaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Purchase purchase)
        {
            purchase.PurchaseItems.RemoveAll(a => a.Quantity == 0);

            try
            {
                await _purchaseService.DeleteRangeAsync(purchase);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetItems()
        {
            return Json(_itemService.All());
        }

        
    }
}
