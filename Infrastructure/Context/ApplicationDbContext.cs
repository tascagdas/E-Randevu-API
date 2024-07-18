using System.Reflection;
using Domain.Entities;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

internal class ApplicationDbContext : IdentityDbContext
    <
        AppUser,
        AppRole,
        Guid,
        IdentityUserClaim<Guid>,
        AppUserRole,
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>
    >
    , IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Bu yöntem ile identity kütüphanesinin oluşturduğu diğer tabloları pasife çekiyoruz.
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();

        //yapılan config dosyalarındaki ayarların uygulanması için. aşağıdaki metod ve parametre verilmeli.
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}