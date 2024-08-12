using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Appointments.UpdateAppointmentCommand;

public class UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateAppointmentCommandRequest, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateAppointmentCommandRequest request,
        CancellationToken cancellationToken)
    {
        Appointment appointment =
            await appointmentRepository.GetByExpressionAsync(a => a.AppointmentId == request.AppointmentId,
                cancellationToken);
        if (appointment is null)
        {
            return Result<string>.Failure("Randevu bulunamadı");
        }

        if (appointment.IsCompleted)
        {
            return Result<string>.Failure("Tamamlanmış randevunun tarihi değiştirilemez.");
        }

        DateTime startDate = Convert.ToDateTime(request.startDate);
        DateTime endDate = Convert.ToDateTime(request.endDate);

        bool isAppointmentTaken = await appointmentRepository
            .AnyAsync(a =>
                    a.DoctorId == appointment.DoctorId && (
                        (a.StarTime < endDate && a.StarTime >= startDate) ||
                        (a.EndTime > startDate && a.EndTime <= endDate) ||
                        (a.StarTime >= startDate && a.EndTime <= endDate) ||
                        (a.StarTime <= startDate && a.EndTime >= endDate)),
                cancellationToken);
        if (isAppointmentTaken)
        {
            return Result<string>.Failure("Bu randevu tarihi müsait değildir.");
        }

        appointment.StarTime = Convert.ToDateTime(request.startDate);
        appointment.EndTime = Convert.ToDateTime(request.endDate);
        appointmentRepository.Update(appointment);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Randevu başarılı bir şekilde güncellendi");
    }
}