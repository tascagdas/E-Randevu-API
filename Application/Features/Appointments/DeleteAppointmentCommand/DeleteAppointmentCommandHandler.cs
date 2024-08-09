using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Appointments.DeleteAppointmentCommand;

public class DeleteAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork):IRequestHandler<DeleteAppointmentCommandRequest,Result<string>>
{
    public async Task<Result<string>> Handle(DeleteAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        Appointment appointment =
            await appointmentRepository.GetByExpressionAsync(a => a.AppointmentId == request.AppointmentId, cancellationToken);
        if (appointment is null)    
        {
            return Result<string>.Failure(404,"Silinmek istenen randevu bulunamadı.");
        }
        if (appointment.IsCompleted)
        {
            return Result<string>.Failure("Silmeye çalıştığınız randevu tamamlandığı için silinemez.");
        }
        appointmentRepository.Delete(appointment);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Randevu silme başarılı.");
    }
}