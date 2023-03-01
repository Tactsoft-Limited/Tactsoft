using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tactsoft.Core.Entities
{
    public class Attendence:BaseEntity
    {
        [Required]
        [DisplayName("Attendence Date")]
        public DateTime AttendenceDate { get; set; }

        [Required]
        [Display(Name ="Employee")]
        public long EmployeeId { get; set; }

        [NotMapped]
        [Display(Name = "Department")]
        public long DepartmentId { get; set; }

        [Required]
        [Display(Name = "Present Status")]
        public Boolean IsPresent { get; set; }


        public Employee Employee { get; set; }
    }
}
