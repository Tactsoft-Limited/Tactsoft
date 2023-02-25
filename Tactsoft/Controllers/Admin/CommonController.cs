using Tactsoft.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Data.DbDependencies;

namespace Tactsoft.Controllers.Admin
{

    public class CommonController : Controller
    {
        private readonly AppDbContext _context;

        public CommonController(AppDbContext context)
        {
            this._context = context;
        }

        public JsonResult GetStatesByCountryId(int countryId)
        {
            List<State> statesList = new List<State>();
            statesList = (from state in _context.States
                          where state.CountryId == countryId
                          select state).ToList();

            return Json(statesList);

        }

        public JsonResult GetCitiesByStateId(int stateId)
        {
            List<City> citiesList = new List<City>();

            citiesList = (from city in _context.Cities
                          where city.StateId == stateId
                          select city).ToList();

            return Json(citiesList);
        }

        public JsonResult GetRandomNumber( int departmentId)
        {
            string date = DateTime.Now.ToString("yyyy");
            string lastIdNumber = (from n in _context.Employees
                                   where n.DepartmentId == departmentId
                                   orderby n.Id descending
                                   select n.IdNumber).FirstOrDefault();

            if(lastIdNumber != null)
            {
                string[] numbers = lastIdNumber.Split('-');
                string lastId = numbers[1].Substring(numbers[1].Length - 5);
                var randomNumber = numbers[0] + "-" + date + (Convert.ToInt32(lastId) + 1).ToString();
                return Json(randomNumber);
            }
            else
            {
                string department = (from d in _context.Departments
                                    where d.Id== departmentId
                                    select d.DepartmentName).FirstOrDefault();

                var randomNumber = department + "-" + date + (10001).ToString();
                return Json(randomNumber);
            }

        }

    }
}
