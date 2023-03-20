using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.ViewModel
{
    public class PurchaseDetailViewModel:MasterEntity
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double Amount { get; set; }
    }
}
