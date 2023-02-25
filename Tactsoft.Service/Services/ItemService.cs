using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class ItemService : BaseService<Item>, IItemService
    {
        public ItemService(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ItemName,
                Value = x.Id.ToString(),
            });
        }
    }
}
