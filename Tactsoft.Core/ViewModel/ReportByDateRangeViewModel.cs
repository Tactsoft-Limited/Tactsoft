using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Core.ViewModel
{
    public class ReportByDateRangeViewModel
    {
        public DateTime PurchaseDate { get; set; }
        public string PurchaseCode { get; set; }
        public string Supplier { get; set; }
       
        public virtual ICollection<PurchaseDetailViewModel> PurchaseDetailViewModels { get; set; }
    }
}
