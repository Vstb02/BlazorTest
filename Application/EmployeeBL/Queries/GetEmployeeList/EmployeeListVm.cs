using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeBL.Queries.GetEmployeeList
{
    public class EmployeeListVm
    {
        public IList<EmployeeItemDto> Lists { get; set; } = new List<EmployeeItemDto>();
    }
}
