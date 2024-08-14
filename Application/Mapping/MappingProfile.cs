using Application.Features.Doctors.CreateDoctor;
using Application.Features.Doctors.UpdateDoctor;
using Application.Features.Patients.CreatePatientCommand;
using Application.Features.Patients.UpdatePatientCommand;
using Application.Features.Users.CreateUser;
using Application.Features.Users.UpdateUserCommand;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommandRequest, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
        });
        CreateMap<UpdateDoctorCommandRequest, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
        });
        CreateMap<CreatePatientCommandRequest, Patient>();
        CreateMap<UpdatePatientCommandRequest, Patient>();
        CreateMap<CreateUserCommandRequest, AppUser>();
        CreateMap<UpdateUserCommandRequest, AppUser>();
    }
}