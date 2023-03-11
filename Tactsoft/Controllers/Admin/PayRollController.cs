using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class PayRollController : Controller
    {
        private readonly IAllowanceDeductionService _allowanceDeductionService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public PayRollController(IAllowanceDeductionService allowanceDeductionService, IDepartmentService departmentService, IEmployeeService employeeService)
        {
            this._allowanceDeductionService = allowanceDeductionService;
            this._departmentService = departmentService;
            this._employeeService = employeeService;
        }


        [HttpGet]
        public async Task<IActionResult> AllowanceDeductionList()
        {
            return View(await _allowanceDeductionService.GetAllAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllowanceDeductionList(AllowanceDeduction model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    await _allowanceDeductionService.UpdateAsync(model.Id, model);
                    return RedirectToAction("AllowanceDeductionList");
                }
                if (_allowanceDeductionService.All().Any(x => x.AllowanceDeductionName == model.AllowanceDeductionName))
                {
                    ModelState.AddModelError("AllowanceDeductionName", "Already Exists!");
                    return View(await _allowanceDeductionService.GetAllAsync());
                }
                await _allowanceDeductionService.InsertAsync(model);
                return RedirectToAction("AllowanceDeductionList");
            }
            return View(await _allowanceDeductionService.GetAllAsync());
        }

        [HttpGet]
        public IActionResult EmployeeSalarySetup()
        {
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AllowanceDeductionId"] = _allowanceDeductionService.Dropdown();
            return View();
        }

    }
}
