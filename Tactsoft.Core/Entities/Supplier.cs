using System.ComponentModel.DataAnnotations;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Supplier:BaseEntity
    {
        public string Name { get; set; }

        [Display(Name= "Contact Person")]
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
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
