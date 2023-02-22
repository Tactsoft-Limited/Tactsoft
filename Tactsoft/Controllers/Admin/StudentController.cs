using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Tactsoft.Controllers.Admin
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        public StudentController(IStudentService studentService, ICountryService countryService,
            IStateService stateService, ICityService cityService)
        {
            this._studentService = studentService;
            this._countryService = countryService;
            this._stateService = stateService;
            this._cityService = cityService;
        }
        // GET: StudentController
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync(x=>x.Country, x=>x.State, x => x.City);
            return View(students);
        }

        // GET: StudentController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.FindAsync(x=>x.Id == id, e=>e.Country, e=>e.State, e=>e.City);
            return PartialView("Details",student);
        }

        // GET: StudentController/Create
        public IActionResult Create()
        {
            Student student = new Student();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            return PartialView("Create", student);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/students",
                     pictureFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    student.Picture = $"{pictureFile.FileName}";
                }
                await _studentService.InsertAsync(student);

                TempData["successAlert"] = "Student save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            return View("Create", student);
        }

        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            return PartialView(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var _student = await _studentService.FindAsync(student.Id);

                    if (pictureFile != null && pictureFile.Length > 0)
                    {                       
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/students",
                         pictureFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        student.Picture = $"{pictureFile.FileName}";
                    }
                    else
                    {
                        student.Picture = _student.Picture;
                    }
                    _student.Picture = student.Picture;
                    _student.StudentName = student.StudentName;
                    _student.StudentEmail = student.StudentEmail;
                    _student.StudentPhone = student.StudentPhone;
                    _student.Address = student.Address;
                    _student.GenderId = student.GenderId;
                    _student.Ssc = student.Ssc;
                    _student.Hsc = student.Hsc;
                    _student.Bsc = student.Bsc;
                    _student.CountryId = student.CountryId;
                    _student.StateId = student.StateId;
                    _student.CityId = student.CityId;

                    await _studentService.UpdateAsync(_student);
                }
                catch
                {
                    throw;
                }
                TempData["successAlert"] = "Student update successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var student = await _studentService.FindAsync(id);
            if (student != null)
            {
               await _studentService.DeleteAsync(student);
            }
            return new JsonResult(student);
        }
    }
}
