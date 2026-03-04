using Budweg_KommeGaaSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class EmployeeViewModel
    {
        private Employee _employee;

        public string EmployeeName 
        {
            get { return $"{_employee.FirstName} {_employee.LastName}"; }
        }

        public int EmployeeId 
        { 
            get { return _employee.EmployeeId; }
        }

        public string EmployeeText
        {
            get { return $"{EmployeeId}: {EmployeeName}"; }
        }

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }
    }
}
