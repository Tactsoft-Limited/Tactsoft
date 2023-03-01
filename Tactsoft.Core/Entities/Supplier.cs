﻿using System.ComponentModel.DataAnnotations;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities
{
    public class Supplier:BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string SupplierName { get; set; }

        [Required]
        [Display(Name= "Contact Person")]
        public string ContactPerson { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string SupplierEmail { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string SupplierPhone { get; set; }
        [Display(Name = "Address")]
        public string SupplierAddress { get; set; }
        [Display(Name = "Country")]
        public long CountryId { get; set; }
        [Display(Name = "State")]
        public long StateId { get; set; }
        [Display(Name = "City")]
        public long CityId { get; set; }

        [Display(Name= "Postal Code")]
        public string PostalCode { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }


        public IList<Purchase> Purchases { get; set;}
    }
}
