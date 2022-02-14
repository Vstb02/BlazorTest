using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeBL.Queries.GetEmployeeList
{
    public class EmployeeItemDto : IMapFrom<Employee>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public byte[]? Profile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeItemDto>()
                .ForMember(empDto => empDto.Id,
                    opt => opt.MapFrom(emp => emp.Id))
                .ForMember(empDto => empDto.Name,
                    opt => opt.MapFrom(emp => emp.Name))
                .ForMember(empDto => empDto.Surname,
                    opt => opt.MapFrom(emp => emp.Surname))
                .ForMember(empDto => empDto.Patronymic,
                    opt => opt.MapFrom(emp => emp.Patronymic))
                .ForMember(empDto => empDto.Profile,
                    opt => opt.MapFrom(emp => emp.Profile));
        }
    }
}
