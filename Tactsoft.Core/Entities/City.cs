using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tactsoft.Core.Entities
{
    public class City:BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string CityName { get; set; }
        [Required]
        [Display(Name = "State")]
        public long StateId { get; set; }

        public State State { get; set; }

        public IList<Student> Students { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
