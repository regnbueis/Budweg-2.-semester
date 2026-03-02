using Budweg_KommeGaaSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class EmployeeViewModel
    {
        private Employee _employee;

        public string EmployeeName { get; set; }

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
            EmployeeName = $"{_employee.EmployeeId}: {_employee.FrontName} {_employee.LastName}";
        }
    }
}
