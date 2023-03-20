using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.ViewModel;
using Tactsoft.Data.DbDependencies;

namespace Tactsoft.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;
        private readonly IItemService _itemService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        public ReportService(AppDbContext context, IItemService itemService, IStateService stateService, ICityService cityService, ICountryService countryService)
        {
            this._context = context;
            this._itemService = itemService;
            this._stateService = stateService;
            this._cityService = cityService;
            this._countryService = countryService;
        }
        public InvoiceReportViewModel GetInvoiceReportData(long id)
        {
            InvoiceReportViewModel invoiceReportViewModel = new InvoiceReportViewModel();
            invoiceReportViewModel.PurchaseViewModel = GetByPurchaseReportData(id);
            invoiceReportViewModel.PurchaseDetailViewModels = GetByPurchaseDetailsList(id);
            invoiceReportViewModel.SupplierInfoViewModel = GetBySupplierInfo(invoiceReportViewModel.PurchaseViewModel.SupplierId);
            return invoiceReportViewModel;
        }

        private SupplierInfoViewModel GetBySupplierInfo(long? supplierId)
        {
            return (from _supplier in _context.Suppliers
                    where _supplier.Id == supplierId
                    select new SupplierInfoViewModel
                    {
                        Id = _supplier.Id,
                        SupplierName = _supplier.SupplierName,
                        ContactPerson = _supplier.ContactPerson,
                        SupplierPhone = _supplier.SupplierPhone,
                        SupplierEmail = _supplier.SupplierEmail,
                        SupplierAddress = _supplier.SupplierAddress,
                        Country = _countryService.NameById(_supplier.CountryId),
                        State = _stateService.NameById(_supplier.StateId),
                        City = _cityService.NameById(_supplier.CityId)
                    }).FirstOrDefault();
        }

        private List<PurchaseDetailViewModel> GetByPurchaseDetailsList(long id)
        {
            return (from _purchaseItems in _context.PurchaseItems
                                    join _items in _context.Items
                                    on _purchaseItems.ItemId equals _items.Id
                                    where (_purchaseItems.PurchaseId == id)
                                    select new PurchaseDetailViewModel
                                    {
                                        Id = _purchaseItems.Id,
                                        ItemId = _purchaseItems.ItemId,
                                        ItemName = _itemService.NameById(_purchaseItems.ItemId),
                                        PurchasePrice = _purchaseItems.PurchasePrice,
                                        Quantity = _purchaseItems.Quantity,
                                        Amount = (_purchaseItems.PurchasePrice) * (_purchaseItems.Quantity)                                        
                                    }).ToList();
             
        }

        private PurchaseViewModel GetByPurchaseReportData(long id)
        {
            return (from _purchase in _context.Purchases
                    where _purchase.Id == id
                    select new PurchaseViewModel
                    {
                        Id = _purchase.Id,
                        PurchaseCode = _purchase.PurchaseCode,
                        Attn = _purchase.Attn,
                        DiscountAmount = _purchase.DiscountAmount,
                        DiscountPercent = _purchase.DiscountPercent,
                        LcDate = _purchase.LcDate,
                        LcNumber = _purchase.LcNumber,
                        PaymentAmount = _purchase.PaymentAmount,
                        PaymentType = _purchase.PaymentType,
                        PoNumber = _purchase.PoNumber,
                        PurchaseDate = _purchase.PurchaseDate,
                        PurchaseType = _purchase.PurchaseType,
                        SupplierId = _purchase.SupplierId,
                        TotalAmount = _purchase.TotalAmount,
                        VatAmount = _purchase.VatAmount,
                        VatPercent = _purchase.VatPercent

                    }).FirstOrDefault();
        }

        
    }
}
