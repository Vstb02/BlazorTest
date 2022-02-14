using Application.Common.Mapping;
using Application.EmployeeBl.Commands.CreateEmployee;
using AutoMapper;

namespace WebApi.Models
{
    public class CreateEmployeeDto : IMapFrom<CreateEmployeeCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public byte[] Profile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>()
                .ForMember(EmpCommand => EmpCommand.Name,
                    opt => opt.MapFrom(empDto => empDto.Name))
                .ForMember(EmpCommand => EmpCommand.Surname,
                    opt => opt.MapFrom(empDto => empDto.Surname))
                .ForMember(EmpCommand => EmpCommand.Patronymic,
                    opt => opt.MapFrom(empDto => empDto.Patronymic))
                .ForMember(EmpCommand => EmpCommand.Profile,
                    opt => opt.MapFrom(empDto => empDto.Profile));
        }
    }
}
