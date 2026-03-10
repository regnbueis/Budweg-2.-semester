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
            get { return _registration.Arrival; }
        }

        public string EmployeeName 
        { 
            get { return $"{_employee.FirstName} {_employee.LastName}"; } 
        }

        public string Text
        {
            get { return $"{Arrival.ToString("HH.mm")}: {EmployeeName}"; }
        }

        public RegistrationViewModel(Registration reg, Employee employee)
        {
            _registration = reg;
            _employee = employee;
        }
    }
}
