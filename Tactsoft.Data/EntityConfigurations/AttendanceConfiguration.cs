using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendence>
    {
        public void Configure(EntityTypeBuilder<Attendence> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.Attendances).HasForeignKey(x => x.EmployeeId);
        }
    }
}
