using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.ViewModel;

namespace Tactsoft.Service.Services
{
    public interface IReportService
    {
        InvoiceReportViewModel GetInvoiceReportData(long id);
    }
}
