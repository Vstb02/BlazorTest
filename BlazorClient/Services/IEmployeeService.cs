using Domain.Entities;

namespace BlazorClient.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
