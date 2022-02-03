using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.EmployeeBL.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public byte[]? Profile { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Surname { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Patronymic { get; set; }
    }
}
