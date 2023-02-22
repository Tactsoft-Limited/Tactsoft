using System.ComponentModel.DataAnnotations;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Item:BaseEntity
    {
        public Item() 
        {
            this.PurchaseItems = new HashSet<PurchaseItem>();
        }

        [Display(Name ="Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }
        public string Discription { get; set; }

        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
