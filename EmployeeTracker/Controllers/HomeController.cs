using Business.Abstract;
using Data.DataModel;
using EmployeeTracker.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeTracker.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //************************************
        //******** View Methods  **********
        //************************************

        public IActionResult Index()
        {
            var model = new EmployeeModel()
            {
                Employees = _employeeService.GetEmployeeWithDepartment(),
            };
            return View(model);
        }
        public IActionResult ViewAllDepartments()
        {
            var model = new EmployeeModel()
            {
                Departments = _employeeService.GetDepartmentList()
            };
            return View(model);
        }


        //************************************
        //******** Employee Methods  **********
        //************************************
        public IActionResult AddEmployee()
        {
            var deparments = _employeeService.GetDepartmentList();
            ViewBag.Departments = deparments;
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDataModel model, int departmentId)
        {
            _employeeService.CreateEmployeeWithDepartment(model.employee, departmentId);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int empId)
        {
            var entity = _employeeService.GetById(empId);
            if (entity != null)
            {
                _employeeService.Delete(entity);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployee(int Id)
        {

            var entity = _employeeService.GetByIdWithDepartment(Id);
            ViewBag.Departments = _employeeService.GetDepartmentList();
            if (entity == null)
            {
                return NotFound();
            }
            var model = new UpdateEmployeeDataModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                SurName = entity.SurName,
                Country = entity.Country,
                DepartmentId = entity.DepartmentId,
                Email = entity.Email,
                Salary = entity.Salary,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(UpdateEmployeeDataModel model)
        {
            var entity = _employeeService.GetByIdWithDepartment(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            entity.SurName = model.SurName;
            entity.Country = model.Country;
            entity.DepartmentId = model.DepartmentId;
            entity.Email = model.Email;
            entity.Salary = model.Salary;
            _employeeService.UpdateEmployee(model);
            return RedirectToAction("Index");

        }

        //***************************************
        //******** Department Methods  **********
        //***************************************

        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDataModel model)
        {
            _employeeService.CreateDepartment(model);
            return RedirectToAction("ViewAllDepartments");
        }

        public IActionResult UpdateDepartment(int id)
        {
            var entity = _employeeService.GetDepartmentById(id);
            if (entity != null)
            {
                var model = new UpdateDepartmentModel()
                {
                    Id = entity.Id,
                    DepartmentName = entity.DepartmentName,
                };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateDepartment(UpdateDepartmentDataModel model)
        {
            var entity = _employeeService.GetDepartmentById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.DepartmentName = model.DepartmentName;
            _employeeService.UpdateDepartment(model);
            return RedirectToAction("ViewAllDepartments");
        }



        public IActionResult DeleteDepartment(int id)
        {
            _employeeService.DeleteDepartment(id);
            return RedirectToAction("ViewAllDepartments");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}