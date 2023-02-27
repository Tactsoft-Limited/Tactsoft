using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Core.Entities
{
    
    public class State:BaseEntity
    {
        [Display(Name = "Name")]
        [Required]
        public string StateName { get; set; }

        [Display(Name= "Country")]
        public long CountryId { get; set; }

        public Country Country { get; set; }

        public IList<City> Cities { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
