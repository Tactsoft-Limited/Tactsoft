using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ReportController : Controller
    {
        private readonly string footer = "--footer-center \"Printed on: " + DateTime.Now.Date.ToString("MM/dd/yyyy") + "  Page: [page]/[toPage]\"" + " --footer-line --footer-font-size \"10\" --footer-spacing 6 --footer-font-name \"calibri light\"";
        private readonly AppDbContext _context;
        private readonly IItemService itemService;
        private readonly IReportService _reportService;

        public ReportController(AppDbContext context, IItemService itemService, IReportService reportService)
        {
            this._context = context;
            this.itemService = itemService;
            this._reportService = reportService;
        }

        public IActionResult PrintInvoice(long id)
        {
            var result = _reportService.GetInvoiceReportData(id);
            return View(result);
        }

        public IActionResult DownloadInvoicePDF(long id)
        {
            var result = _reportService.GetInvoiceReportData(id);
            var rpt = new ViewAsPdf();
            rpt.PageOrientation = Orientation.Portrait;
            rpt.CustomSwitches = footer;
            rpt.FileName = "Purchase_Invoice" + id + ".pdf";
            rpt.ViewName = "DownloadInvoicePDF";
            rpt.Model = result;
            return rpt;
        }

    }
}
