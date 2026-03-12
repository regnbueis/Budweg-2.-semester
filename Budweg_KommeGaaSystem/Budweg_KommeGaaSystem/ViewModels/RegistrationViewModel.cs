using System;
using System.Collections.Generic;
using System.Text;
using Budweg_KommeGaaSystem.Models;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class RegistrationViewModel
    {
        private Registration _registration;
        private Employee _employee;

        public DateTime Arrival
        {
            get => _registration.Arrival;
        }

        public string EmployeeName 
        { 
            get => $"{_employee.FirstName} {_employee.LastName}";
        }

        public string Text
        {
            get => $"{Arrival.ToString("HH.mm")}: ({EmployeeId}) {EmployeeName}";
        }

        public int EmployeeId
        {
            get => _employee.EmployeeId;
        }

        public RegistrationViewModel(Registration reg, Employee employee)
        {
            _registration = reg;
            _employee = employee;
        }
    }
}
