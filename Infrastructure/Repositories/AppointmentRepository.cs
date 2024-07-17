using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

internal class AppointmentRepository : Repository<Appointment,ApplicationDbContext>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
        
    }
}