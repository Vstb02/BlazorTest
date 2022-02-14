using Application.Common.Mapping;
using Application.EmployeeBL.Commands.UpdateEmployee;
using AutoMapper;

namespace WebApi.Models
{
    public class UpdateEmployeeDto : IMapFrom<UpdateEmployeeCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public byte[] Profile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>()
                .ForMember(EmpCommand => EmpCommand.Id,
                    opt => opt.MapFrom(empDto => empDto.Id))
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
