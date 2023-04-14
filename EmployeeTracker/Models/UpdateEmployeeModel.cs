using Entity;

namespace EmployeeTracker.Models
{
    public class UpdateEmployeeModel
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
