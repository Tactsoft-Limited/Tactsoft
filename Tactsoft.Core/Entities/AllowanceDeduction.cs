using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities
{
    public class AllowanceDeduction:BaseEntity
    {
        [Required]
        [Display(Name = "Allowance/Deduction Name")]
        public string AllowanceDeductionName { get; set; }
        [Required]
        [Display(Name = "Allowance/Deduction Type")]
        public string AllowanceDeductionType { get; set; }

        public ICollection<EmployeeSalaryDetail> EmployeeSalaryDetailes { get; set; }
    }
}
