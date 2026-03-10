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
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT EmployeeId, FirstName, LastName, Department FROM EMPLOYEE";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeId = dr.GetInt32(0),
                            FirstName = (string)dr["FirstName"],
                            LastName = (string)dr["LastName"],
                            Department = (string)dr["Department"]
                        };

                        employees.Add(employee);
                    }
                }
            }
        }

        public Employee? GetEmployeeById(int employeeId)
        {
            return employees
                .Where(x => x.EmployeeId == employeeId)
                .FirstOrDefault();
        }
    }
}
