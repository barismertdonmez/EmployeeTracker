using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class UpdateEmployeeDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
