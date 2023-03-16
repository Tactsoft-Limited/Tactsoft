using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Tactsoft.Core.Entities;

namespace Tactsoft.Core.ViewModel
{
    public class SalarySetupModel
    {
        public SalarySetupModel()
        {
            SalarySetupList = new Collection<SalarySetupList>();
        }

        [Required]
        [DisplayName("Department")]
        public long DepartmentId { get; set; }

        [Required] 
        [DisplayName("Employee")]
        public long EmployeeId { get; set; }

        public ICollection<SalarySetupList> SalarySetupList { get; set; }
  
    }
    public class SalarySetupList
    {
        public long SalarySetupId { get; set; }
        public long AllowanceDeductionId { get; set; }
        public string AllowanceDeductionName { get; set; }
        public string AllowanceDeductionType { get; set; }
        public Boolean IsPercent { get; set; }
        public double Value { get; set; }
    }
}
