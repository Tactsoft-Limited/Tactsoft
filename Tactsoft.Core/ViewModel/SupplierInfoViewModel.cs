using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.ViewModel
{
    public class SupplierInfoViewModel:MasterEntity
    {
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
