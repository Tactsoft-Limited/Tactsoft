using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x=> new SelectListItem
            {
                Text = x.EmployeeName +"("+ x.IdNumber+")",
                Value = x.Id.ToString(),
            });
        }

        public IEnumerable<Employee> AllByDepartmentId(int deptId)
        {
            if (deptId == 0)
                return All();
            return All().Where(x => x.DepartmentId == deptId);
        }

        public IEnumerable<SelectListItem> GetAllEmployeeForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.EmployeeName,
                Value = x.Id.ToString(),
            });
        }

        public string NameById(long id)
        {
            var emp = Find(id);
            return emp.EmployeeName;
        }
    }
}
