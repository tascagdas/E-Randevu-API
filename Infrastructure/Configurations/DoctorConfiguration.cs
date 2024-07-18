using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(d => d.FirstName).HasColumnType("varchar(50)");
        builder.Property(d => d.LastName).HasColumnType("varchar(40)");

        builder.Property(d => d.Department)
            .HasConversion(v => v.Value,
                v => DepartmentEnum.FromValue(v))
            .HasColumnName("Department");
    }
}