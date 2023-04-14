using Data.Abstract;
using Data.DataModel;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class EfCoreEmployeeRepository : EfCoreGenericRepository<Employee, EmployeeTrackerContext>, IEmployeeRepository
    {
        public void CreateDepartment(AddDepartmentDataModel department)
        {
            using (var context = new EmployeeTrackerContext())
            {
                var dpt = new Department()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName,
                };
                context.Add(dpt);
                context.SaveChanges();
            }
        }

        public void CreateEmployeeWithDepartment(Employee employee, int departmentId)
        {
            using (var context = new EmployeeTrackerContext())
            {
                var emp = new Employee()
                {
                    Id = employee.Id,
                    DepartmentId = departmentId,
                    Country = employee.Country,
                    Email = employee.Email,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    SurName = employee.SurName,
                };
                context.Add(emp);
                context.SaveChanges();
            }
        }

        public void DeleteDepartment(int id)
        {
            using (var context = new EmployeeTrackerContext())
            {
                var dpt = context.Departments
                                 .Where(d => d.Id == id)
                                 .FirstOrDefault();
                context.Remove(dpt);
                context.SaveChanges();
            }
        }

        public Employee GetByIdWithDepartment(int id)
        {
            using(var context = new EmployeeTrackerContext()) 
            {
                return context.Employees
                              .Where(e => e.Id == id)
                              .Include(e => e.Department)
                              .FirstOrDefault();
            }
        }

        public Department GetDepartmentById(int id)
        {
            using (var context = new EmployeeTrackerContext())
            {
                return context.Departments
                              .Where(e => e.Id == id)
                              .FirstOrDefault();
            }
        }

        public List<Department> GetDepartmentList()
        {
            using (var context = new EmployeeTrackerContext())
            {
                var dpt = context.Departments;
                return dpt.ToList();
            }
        }

        public List<Employee> GetEmployeeWithDepartment()
        {
            using (var context = new EmployeeTrackerContext())
            {
                var emp = context.Employees
                                 .Include(x => x.Department);
                return emp.ToList();
            }
        }

        public void UpdateDepartment(UpdateDepartmentDataModel model)
        {
            using (var context = new EmployeeTrackerContext())
            {
                var dpt = new Department()
                {
                    Id = model.Id,
                    DepartmentName = model.DepartmentName,
                };
                context.Update(dpt);
                context.SaveChanges();
            }
        }

        public void UpdateEmployee(UpdateEmployeeDataModel model)
        {
            using (var context = new EmployeeTrackerContext())
            {
                var emp = new Employee()
                {
                    Id = model.Id,
                    Name = model.Name,
                    SurName = model.SurName,
                    Email = model.Email,
                    Country = model.Country,
                    DepartmentId = model.DepartmentId,
                    Salary = model.Salary,
                };
                context.Update(emp);
                context.SaveChanges();
            }
        }
    }
}
