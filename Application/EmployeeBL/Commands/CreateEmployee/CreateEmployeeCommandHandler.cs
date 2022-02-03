using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeBl.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateEmployeeCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = new Employee
            {
                Id = Guid.NewGuid(),
                Profile = request.Profile,
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Create = DateTime.Now
            };

            await _dbContext.Employees.AddAsync(emp, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return emp.Id;
        }

    }
}
