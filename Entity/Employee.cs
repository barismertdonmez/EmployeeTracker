using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
