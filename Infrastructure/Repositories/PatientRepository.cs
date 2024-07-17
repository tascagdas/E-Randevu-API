using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

internal class PatientRepository : Repository<Patient,ApplicationDbContext>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context)
    {
        
    }
}