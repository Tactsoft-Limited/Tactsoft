using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
