namespace BlazorClient.Models
{
    public class EmployeeVm
    {
        public IList<EmployeeItemDto> Lists { get; set; } = new List<EmployeeItemDto>();
    }
}
