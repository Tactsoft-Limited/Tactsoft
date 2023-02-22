using Tactsoft.Core;
using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Core.Entities
{
    public class Student:BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string StudentEmail { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string StudentPhone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "DOB")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Gender")]
        public Gender GenderId { get; set; }

        public Boolean Ssc { get; set; }
        public Boolean Hsc { get; set; }
        public Boolean Bsc { get; set; }

        public string Picture { get; set; }

        [Required]
        [ForeignKey("Country")]
        [Display(Name = "Country")]
        public long CountryId { get; set; }

        [Required]
        [ForeignKey("State")]
        [Display(Name = "State")]
        public long StateId { get; set; }

        [Required]
        [ForeignKey("City")]
        [Display(Name = "City")]
        public long CityId { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }
}
