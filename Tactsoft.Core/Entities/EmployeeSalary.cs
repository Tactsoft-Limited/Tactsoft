using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Tactsoft.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tactsoft.Core.Entities
{
    public class EmployeeSalary:BaseEntity
    {
        public EmployeeSalary()
        {
            EmployeeSalaryDetails = new List<EmployeeSalaryDetail>();
        }


        [Required]
        [DisplayName("Employee")]
        public long EmployeeId { get; set; }

        [Required]
        [DisplayName("Basic Salary")]
        public double BasicSalary { get; set; }


        [NotMapped]
        [DisplayName("Department")]
        public long DepartmentId { get; set; }

        public virtual ICollection<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }

    }
}
