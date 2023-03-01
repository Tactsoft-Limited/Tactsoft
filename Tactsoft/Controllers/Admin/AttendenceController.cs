using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Core.ViewModel;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AttendenceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public AttendenceController(IAttendanceService attendanceService, IDepartmentService departmentService,
            IEmployeeService employeeService) 
        {
            this._attendanceService = attendanceService;
            this._departmentService = departmentService;
            this._employeeService = employeeService;
        }
        public IActionResult Index()
        {
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Index(AttendenceReport model)
        {
            ViewData["DepartmentId"] = _departmentService.Dropdown();

            var employees = _employeeService.AllByDepartmentId(model.DepartmentId);

            int days = DateTime.DaysInMonth(DateTime.Now.Year, model.Month);
            DateTime firstdayofmonth = new DateTime(DateTime.Now.Year, model.Month, 1);
            DateTime lastdayofmonth = new DateTime(DateTime.Now.Year, model.Month, 1).AddMonths(1).AddDays(-1);

            var attendences = _attendanceService.All().Where(x => x.AttendenceDate >= firstdayofmonth && x.AttendenceDate <= lastdayofmonth).ToList();
            AttendenceReport attendenceReport = new AttendenceReport();
            attendenceReport.DepartmentId = model.DepartmentId;
            attendenceReport.Month = model.Month;

            for (int i = 1; i <= days; i++)
            {
                string currentDate = new DateTime(DateTime.Now.Year, model.Month, i).ToShortDateString();
                attendenceReport.AllCurrentMonthDate.Add(currentDate);
            }

            foreach (var item in employees)
            {
                EmployeeAttendenceStatus empStatusVm = new EmployeeAttendenceStatus(days, model.Month);
                empStatusVm.EmployeeId = (int)item.Id;
                empStatusVm.EmployeeName = item.EmployeeName;
                var attendenceWithEmployee = attendences.Where(x => x.EmployeeId == item.Id).OrderBy(x => x.AttendenceDate).ToList();
                foreach (var attEmp in attendenceWithEmployee)
                {
                    string attndDate = attEmp.AttendenceDate.ToShortDateString();

                    if (attendenceReport.AllCurrentMonthDate.Contains(attndDate))
                    {
                        var statusR = empStatusVm.attendenceStatus.FindIndex(x => x.Date.ToShortDateString() == attndDate);
                        empStatusVm.attendenceStatus.RemoveAt(statusR);

                        var status = new AttendenceStatus();
                        status.Date = attEmp.AttendenceDate;
                        if (attEmp.IsPresent == true)
                        {
                            status.Status = "Present";
                        }

                        if (attEmp.IsPresent == false)
                        {
                            status.Status = "Absense";
                        }
                        empStatusVm.attendenceStatus.Insert(statusR, status);
                    }

                }
                attendenceReport.EmployeeAttendenceStatus.Add(empStatusVm);
            }
            return View(attendenceReport);
        }

        // GET: CityController/TakeAttendence
        public ActionResult TakeAttendence()
        {
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            return View(new AttendenceModel());
        }

        // POST: CityController/TakeAttendence
        [HttpPost]
        public ActionResult TakeAttendence(AttendenceModel model)
        {
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            var attendences = _attendanceService.All().Any(x => x.AttendenceDate == model.AttendenceDate);
            AttendenceModel attendenceModel = new AttendenceModel();
            attendenceModel.AttendenceDate = model.AttendenceDate;
            attendenceModel.DepartmentId = model.DepartmentId;
            if (attendences)
            {
                var attendecesList = _attendanceService.All().Where(x => x.AttendenceDate == model.AttendenceDate).ToList();
                foreach (var item in attendecesList)
                {
                    attendenceModel.AttendenceList.Add(new AttendenceList
                    {
                        EmployeeId = item.EmployeeId,
                        AttendenceId = item.Id,
                        IsPresent = item.IsPresent,
                        Name = _employeeService.NameById(item.EmployeeId)
                    });
                }
                return View(attendenceModel);
            }

            var employees = _employeeService.AllByDepartmentId(model.DepartmentId);
            if (employees != null)
            {
                foreach (var item in employees)
                {
                    attendenceModel.AttendenceList.Add(new AttendenceList { EmployeeId = item.Id, Name = item.EmployeeName });
                }
                return View(attendenceModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAttendence(AttendenceModel model)
        {
            if (model.AttendenceList.Count() > 0)
            {
                foreach (var item in model.AttendenceList)
                {
                    if (item.AttendenceId == 0)
                    {
                        //save 
                        await _attendanceService.InsertAsync(new Attendence
                        {
                            AttendenceDate = model.AttendenceDate,
                            EmployeeId = item.EmployeeId,
                            IsPresent = item.IsPresent });
                    }
                    else
                    {
                        // update 
                        var existingAttendence = await _attendanceService.FindAsync(item.AttendenceId);
                        if (existingAttendence != null)
                        {
                            existingAttendence.IsPresent = item.IsPresent;
                            existingAttendence.EmployeeId = item.EmployeeId;
                            await _attendanceService.UpdateAsync(existingAttendence.Id, existingAttendence);
                        }
                    }
                }
            }
            return RedirectToAction("TakeAttendence");
        }

    }
}
