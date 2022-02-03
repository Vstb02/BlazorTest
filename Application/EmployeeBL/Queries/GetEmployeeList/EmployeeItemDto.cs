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
    public class EmployeeItemDto : IMapWith<Employee>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public byte[]? Profile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeItemDto>()
                .ForMember(agentDto => agentDto.Id,
                    opt => opt.MapFrom(agent => agent.Id))
                .ForMember(agentDto => agentDto.Name,
                    opt => opt.MapFrom(agent => agent.Name))
                .ForMember(agentDto => agentDto.Surname,
                    opt => opt.MapFrom(agent => agent.Surname))
                .ForMember(agentDto => agentDto.Patronymic,
                    opt => opt.MapFrom(agent => agent.Patronymic))
                .ForMember(agentDto => agentDto.Profile,
                    opt => opt.MapFrom(agent => agent.Profile));
        }
    }
}
