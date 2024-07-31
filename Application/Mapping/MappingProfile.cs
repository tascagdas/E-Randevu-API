using Application.Features.Doctors.CreateDoctor;
using Application.Features.Doctors.UpdateDoctor;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Options;

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
    }
}