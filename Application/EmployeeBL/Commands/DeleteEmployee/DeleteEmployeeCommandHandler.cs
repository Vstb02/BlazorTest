using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.EmployeeBL.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteEmployeeCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
