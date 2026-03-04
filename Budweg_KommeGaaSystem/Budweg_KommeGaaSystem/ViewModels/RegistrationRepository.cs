using System;
using System.Collections.Generic;
using System.Data;
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

            registrations = new List<Registration>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                
                string query = "SELECT RegistrationId, Arrival, Departure, EmployeeId, BuildingId FROM REGISTRATION";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Registration registration = new Registration()
                        {
                            RegistrationId = (int)dr["RegistrationId"],
                            Arrival = dr.GetDateTime("Arrival"),
                            Departure = dr.IsDBNull("Departure") ? null : dr.GetDateTime("Departure"),
                            EmployeeId = (int)dr["EmployeeId"],
                            BuildingId = (int)dr["BuildingId"]
                        };

                        registrations.Add(registration);
                    }
                }
            }
        }

        public List<Registration> GetAll()
        {
            return registrations;
        }

        public List<Registration> GetAllByBuildingId(int buildingId)
        {
            return registrations
                .Where(x => x.BuildingId == buildingId)
                .ToList();
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
