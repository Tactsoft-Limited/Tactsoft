using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public interface IEmployeeService:IBaseService<Employee>
    {
        IEnumerable<Employee> AllByDepartmentId(int deptId);
        IEnumerable<SelectListItem> GetAllEmployeeForDropDown();
        string NameById(int id);
    }
}
