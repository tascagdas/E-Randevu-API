using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("Sqlite"));
        });
        serviceCollection.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredUniqueChars = 0;
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        serviceCollection.AddScoped<IAppointmentRepository, AppointmentRepository>();
        serviceCollection.AddScoped<IDoctorRepository, DoctorRepository>();
        serviceCollection.AddScoped<IPatientRepository, PatientRepository>();

        serviceCollection.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        
        return serviceCollection;
    }
}