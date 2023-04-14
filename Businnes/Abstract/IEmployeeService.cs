using Data.DataModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        Employee GetById(int id);
        List<Employee> GetAll();
        void Create(Employee entity);
        void Update(Employee entity);
        void Delete(Employee entity);

        List<Employee> GetEmployeeWithDepartment();
        List<Department> GetDepartmentList();
        void CreateEmployeeWithDepartment(Employee employee, int departmentId);
        Employee GetByIdWithDepartment(int id);
        void CreateDepartment(AddDepartmentDataModel department);
        void DeleteDepartment(int id);
        Department GetDepartmentById(int id);
        void UpdateDepartment(UpdateDepartmentDataModel model);
        void UpdateEmployee(UpdateEmployeeDataModel model);
    }
}
