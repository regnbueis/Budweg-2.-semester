using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Budweg_KommeGaaSystem.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class EmployeeRepository
    {
        private readonly string connectionString;
        private List<Employee> employees;

        public EmployeeRepository()
        {
            connectionString = Configuration.ConnectionString;

            employees = new List<Employee>();
        }

        public List<Employee> RetrieveEmployeesByBuildingId(int buildingId)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT EmployeeId, FrontName, LastName, Department " +
                    "From EMPLOYEE WHERE BuildingId = @BuildingId", con);
                cmd.Parameters.AddWithValue("@BuildingId", buildingId);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeId = dr.GetInt32(0),
                            FrontName = (string)dr["FrontName"],
                            LastName = (string)dr["LastName"],
                            Department = (string)dr["Department"]
                        };
                        employees.Add(employee);
                    }
                }

            }

            return employees;
        }

        public void UpdateEmployeeBuildingId(int employeeId, int buildingId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Employee SET BuildingId = @BuildingId " +
                    "WHERE EmployeeId = @EmployeeId", con);

                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
