using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public interface IItemService:IBaseService<Item>
    {
        IEnumerable<SelectListItem> Dropdown();
        string NameById(long itemId);
    }
}
