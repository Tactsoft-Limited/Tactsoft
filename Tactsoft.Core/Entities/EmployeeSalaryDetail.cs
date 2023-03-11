using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Tactsoft.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tactsoft.Core.Entities
{
    public class EmployeeSalaryDetail:BaseEntity
    {
        [Required]
        [ForeignKey("EmployeeSalary")]
        public long EmployeeSalaryId{ get; set; }
        public virtual EmployeeSalary EmployeeSalary { get; private set; }

        [Required]
        [ForeignKey("AllowanceDeduction")]
        [DisplayName("Allowance/Deduction")]
        public long AllowanceDeductionId { get; set; }
        public virtual AllowanceDeduction AllowanceDeduction { get; private set; }

        [Required]
        [DisplayName("Value")]
        public bool IsValue { get; set; }

        [Required]
        public double Value { get; set; }

    }
}
