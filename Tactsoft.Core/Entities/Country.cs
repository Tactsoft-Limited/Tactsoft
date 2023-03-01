using System.ComponentModel.DataAnnotations;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities
{
    public class Country:BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string CountryName { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string CountryCode { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public string CountryCurrency { get; set; }

        [Required]
        [Display(Name = "Flage")]
        public string CountryFlag { get; set; }


        public IList<State> States { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Employee> Employees { get; set; }

    }
}
