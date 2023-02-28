using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Core.ViewModel
{
    public class AttendenceReport
    {
        public AttendenceReport()
        {
            EmployeeAttendenceStatus = new List<EmployeeAttendenceStatus>();
            AllCurrentMonthDate = new List<string>();
        }
        [DisplayName("Department")]
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int Month { get; set; }
        public List<string> AllCurrentMonthDate{ get; set; }

        public List<EmployeeAttendenceStatus> EmployeeAttendenceStatus { get; set; }
    }
    public class EmployeeAttendenceStatus
    {
        public EmployeeAttendenceStatus(int days, int month)
        {
            attendenceStatus = new List<AttendenceStatus>();

            for (int i = 1; i <= days; i++)
            {
                DateTime currentDate = new DateTime(DateTime.Now.Year, month, i);
                this.attendenceStatus.Add(new AttendenceStatus { Date = currentDate, Status = ""});
            }
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public List<AttendenceStatus> attendenceStatus { get; set; }
    }
    public class AttendenceStatus
    {
        public AttendenceStatus()
        {

        }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
