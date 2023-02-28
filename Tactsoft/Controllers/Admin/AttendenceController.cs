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
            return View();
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
                        EmployeeId = (int)item.EmployeeId,
                        AttendenceId = (int)item.Id,
                        IsPresent = item.IsPresent,
                        Name = _employeeService.NameById((int)item.EmployeeId)
                    });
                }
                return View(attendenceModel);
            }
            var employees = _employeeService.AllByDepartmentId(model.DepartmentId);
            if (employees != null)
            {
                foreach (var item in employees)
                {
                    attendenceModel.AttendenceList.Add(new AttendenceList { EmployeeId = (int)item.Id, Name = item.EmployeeName });
                }
                return View(attendenceModel);
            }
            return View(model);
        }

        
    }
}
