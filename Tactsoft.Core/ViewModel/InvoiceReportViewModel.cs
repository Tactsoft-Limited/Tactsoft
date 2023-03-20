using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tactsoft.Core.ViewModel
{
    public class InvoiceReportViewModel
    {
        public SupplierInfoViewModel SupplierInfoViewModel { get; set; }
        public PurchaseViewModel PurchaseViewModel { get; set; }
        public List<PurchaseDetailViewModel> PurchaseDetailViewModels { get; set; }
    }
}
