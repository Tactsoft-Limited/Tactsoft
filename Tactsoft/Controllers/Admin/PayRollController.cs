using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Core.ViewModel;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class PayRollController : Controller
    {
        private readonly IAllowanceDeductionService _allowanceDeductionService;
        private readonly ISalarySetupService _salarySetupService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public PayRollController(IAllowanceDeductionService allowanceDeductionService, IDepartmentService departmentService, IEmployeeService employeeService, ISalarySetupService salarySetupService)
        {
            this._allowanceDeductionService = allowanceDeductionService;
            this._departmentService = departmentService;
            this._employeeService = employeeService;
            this._salarySetupService = salarySetupService;
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

        // GET: CityController/TakeAttendence
        public ActionResult SalarySetup()
        {
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View(new SalarySetupModel());
        }

        [HttpPost]
        public IActionResult SalarySetup(SalarySetupModel model)
        {
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            var salarySatups = _salarySetupService.All().Any(x => x.EmployeeId == model.EmployeeId);
            SalarySetupModel salarySetupModel = new SalarySetupModel();
            salarySetupModel.DepartmentId = model.DepartmentId;
            salarySetupModel.EmployeeId = model.EmployeeId;

            if (salarySatups)
            {
                var salarySatupList = _salarySetupService.All().Where(x => x.EmployeeId == model.EmployeeId).ToList();
                foreach (var item in salarySatupList)
                {
                    salarySetupModel.SalarySetupList.Add(new SalarySetupList
                    {
                        AllowanceDeductionId = item.AllowanceDeductionId,
                        AllowanceDeductionName = _allowanceDeductionService.NameById(item.AllowanceDeductionId),
                        SalarySetupId = item.Id,
                        IsPercent = item.IsPercent,
                        Value = item.Value                     
                    });
                }
                return View(salarySetupModel);
            }

            var ad = _allowanceDeductionService.All();
            if (ad != null)
            {
                foreach (var item in ad)
                {
                    salarySetupModel.SalarySetupList.Add(new SalarySetupList { 
                        AllowanceDeductionId = item.Id, 
                        AllowanceDeductionName = item.AllowanceDeductionName, 
                        AllowanceDeductionType = item.AllowanceDeductionType });
                }
                return View(salarySetupModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveSalarySetup(SalarySetupModel model)
        {
            if (model.SalarySetupList.Count() > 0)
            {
                foreach (var item in model.SalarySetupList)
                {
                    if (item.SalarySetupId == 0)
                    {
                        //save 
                        await _salarySetupService.InsertAsync(new SalarySetup
                        {
                            EmployeeId = model.EmployeeId,
                            AllowanceDeductionId = item.AllowanceDeductionId,
                            IsPercent = item.IsPercent,
                            Value = item.Value
                        });
                    }
                    else
                    {
                        // update 
                        var existingSalarySetup = await _salarySetupService.FindAsync(item.SalarySetupId);
                        if (existingSalarySetup != null)
                        {
                            existingSalarySetup.IsPercent = item.IsPercent;
                            existingSalarySetup.Value = item.Value;
                            existingSalarySetup.AllowanceDeductionId = item.AllowanceDeductionId;
                            await _salarySetupService.UpdateAsync(existingSalarySetup.Id, existingSalarySetup);
                        }
                    }
                }
            }
            return RedirectToAction("SalarySetup");
        }

    }
}
