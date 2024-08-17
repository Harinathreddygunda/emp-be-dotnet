using EmployeePortel.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public EmployeeController(TrainingDBContext _trainingDBContext) {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetEmployeeDetails")]
        public List<Employee> GetEmployeeDetails()
        {
            List<Employee> lstEmoloyee = new List<Employee>();
            try
            {
                lstEmoloyee = trainingDBContext.Employees.ToList();
                return lstEmoloyee;
            }
            catch(Exception ex)
            {
                lstEmoloyee = new List<Employee>();
                return lstEmoloyee;
            }
        }
        [HttpPost("AddEmployee")]
        public string AddEmployee(Employee employee)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(employee.EmpFirstName) && !string.IsNullOrEmpty(employee.EmpLastName) && !string.IsNullOrEmpty(employee.EmpFullName))
                {
                    trainingDBContext.Add(employee);
                    trainingDBContext.SaveChanges();
                    message = "Employee added successfully";
                }
                else
                    message = "Employee FirstName,LastName and FullName required.";

            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
