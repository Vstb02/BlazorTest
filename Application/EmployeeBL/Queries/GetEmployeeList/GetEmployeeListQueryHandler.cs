using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Common.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.EmployeeBL.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, EmployeeListVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetEmployeeListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) => (_mapper, _dbContext) = (mapper, dbContext);

        public async Task<EmployeeListVm> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var empQuery = await _dbContext.Employees
                .ProjectTo<EmployeeItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeeListVm { Lists = empQuery };
        }
    }
}
