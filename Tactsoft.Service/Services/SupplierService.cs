﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        public SupplierService(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
        }
    }
}
