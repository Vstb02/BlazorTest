using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public byte[]? Profile { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
    }
}
