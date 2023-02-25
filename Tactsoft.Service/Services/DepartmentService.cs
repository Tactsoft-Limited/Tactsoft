using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public  IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.Id.ToString(),
            });
        }
    }
}
