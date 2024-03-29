﻿using Tactsoft.Core.Entities;
using Tactsoft.Service.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Data.DbDependencies;

namespace Tactsoft.Service.Services
{
    public class CityService : BaseService<City>, ICityService
    {
        private readonly AppDbContext _context;

        public CityService(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.CityName, Value = x.Id.ToString() });
        }

        public string NameById(long stateId)
        {
            return Find(stateId).CityName;
        }
    }
}
