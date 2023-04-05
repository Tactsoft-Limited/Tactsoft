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
        ReportViewModel GetInvoiceReportData(long id);

        List<ReportByDateRangeViewModel> ReportByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
