using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.EmployeeBL.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateEmployeeCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(emp =>
            emp.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.Patronymic = request.Patronymic;
            employee.Profile = request.Profile;
            employee.Update = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
