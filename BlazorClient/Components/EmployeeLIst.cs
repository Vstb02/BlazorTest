using BlazorClient.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorClient.Components
{
    public class EmployeeLIst : ComponentBase
    {
        [Inject]
        public IEmployeeService employeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set;}

        protected override async Task OnInitializedAsync()
        {
            Employees = (await employeeService.GetEmployees()).ToList();
        }
    }
}
