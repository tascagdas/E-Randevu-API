using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
        builder.Property(p => p.LastName).HasColumnType("varchar(40)");
        builder.Property(p => p.City).HasColumnType("varchar(40)");
        builder.Property(p => p.Town).HasColumnType("varchar(40)");
        builder.Property(p => p.FullAddress).HasColumnType("varchar(250)");
        builder.Property(p => p.IdentityNumber).HasColumnType("varchar(11)");
        builder.HasIndex(p => p.IdentityNumber);
    }
}