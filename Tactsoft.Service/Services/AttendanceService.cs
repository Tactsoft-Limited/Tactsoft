using Tactsoft.Core.Entities;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class AttendanceService : BaseService<Attendence>, IAttendanceService
    {
        private readonly AppDbContext _context;

        public AttendanceService(AppDbContext context) : base(context)
        {
            this._context = context;
        }


    }
}
