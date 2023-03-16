using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class SalarySatupConfiguration : IEntityTypeConfiguration<SalarySetup>
    {
        public void Configure(EntityTypeBuilder<SalarySetup> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Employee).WithMany(x=>x.SalarySetups).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x => x.AllowanceDeduction).WithMany(x=>x.SalarySetups).HasForeignKey(x=>x.AllowanceDeductionId);
        }
    }
}
