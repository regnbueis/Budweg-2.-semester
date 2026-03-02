using System;
using System.Collections.Generic;
using System.Text;
using Budweg_KommeGaaSystem.Models;
using Microsoft.Data.SqlClient;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class RegistrationRepository
    {
        private readonly string connectionString;
        private List<Registration> registrations;

        public RegistrationRepository()
        {
            connectionString = Configuration.ConnectionString;
        }
        public void CreateEmployeeArrival(int employee)
        {
            //IKKE IMPLEMENTERET ENDNU
        }
        public void UpdateEmployeeDeparture(int employee)
        {
            //IKKE IMPLEMENTERET ENDNU
        }


    }
}
