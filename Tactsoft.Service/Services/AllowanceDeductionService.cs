using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class AllowanceDeductionService : BaseService<AllowanceDeduction>, IAllowanceDeductionService
    {
        private readonly AppDbContext _context;

        public AllowanceDeductionService(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.AllowanceDeductionName,
                Value = x.Id.ToString(),
            });
        }

        public string NameById(long id)
        {
            var ad = Find(id);
            return ad.AllowanceDeductionName;
        }
    }
}
