using Application.Features.Doctors.CreateDoctor;
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
            options.MapFrom(map => DepartmentEnum.FromValue(map.Department));
        });
    }
}