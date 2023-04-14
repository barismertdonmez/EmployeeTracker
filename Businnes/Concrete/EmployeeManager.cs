using Business.Abstract;
using Data.Abstract;
using Data.DataModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Create(Employee entity)
        {
            _employeeRepository.Create(entity);
        }

        public void CreateDepartment(AddDepartmentDataModel department)
        {
            _employeeRepository.CreateDepartment(department);
        }

        public void CreateEmployeeWithDepartment(Employee employee, int departmentId)
        {
            _employeeRepository.CreateEmployeeWithDepartment(employee, departmentId);
        }

        public void Delete(Employee entity)
        {
            _employeeRepository.Delete(entity);
        }

        public void DeleteDepartment(int id)
        {
            _employeeRepository.DeleteDepartment(id);
        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public Employee GetByIdWithDepartment(int id)
        {
           return _employeeRepository.GetByIdWithDepartment(id);
        }

        public Department GetDepartmentById(int id)
        {
            return _employeeRepository.GetDepartmentById(id);
        }

        public List<Department> GetDepartmentList()
        {
            return _employeeRepository.GetDepartmentList();
        }

        public List<Employee> GetEmployeeWithDepartment()
        {
            return _employeeRepository.GetEmployeeWithDepartment();
        }

        public void Update(Employee entity)
        {
            _employeeRepository.Update(entity);
        }

        public void UpdateDepartment(UpdateDepartmentDataModel model)
        {
            _employeeRepository.UpdateDepartment(model);
        }

        public void UpdateEmployee(UpdateEmployeeDataModel model)
        {
            _employeeRepository.UpdateEmployee(model);
        }
    }
}
