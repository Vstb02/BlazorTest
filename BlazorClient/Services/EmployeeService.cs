using Domain.Entities;

namespace BlazorClient.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<Employee[]>("api/getall");
        }
    }
}
