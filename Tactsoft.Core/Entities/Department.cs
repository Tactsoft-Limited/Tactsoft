using System.ComponentModel.DataAnnotations;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities
{
    public class Department:BaseEntity
    {
        [Required]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }


        public IList<Employee> Employees { get; set; }
    }
}
