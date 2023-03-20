using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.ViewModel
{
    public class PurchaseViewModel:MasterEntity
    {
        public DateTime PurchaseDate { get; set; } 
        public string PurchaseCode { get; set; }
        public string PurchaseType { get; set; }
        public long? SupplierId { get; set; }
        public string Attn { get; set; }
        public double LcNumber { get; set; }
        public DateTime LcDate { get; set; }
        public double PoNumber { get; set; }
        public double? TotalAmount { get; set; }
        public double? DiscountAmount { get; set; }
        public double? DiscountPercent { get; set; }
        public double? VatAmount { get; set; }
        public double? VatPercent { get; set; }
        public double? PaymentAmount { get; set; }
        public string PaymentType { get; set; }
    }
}
