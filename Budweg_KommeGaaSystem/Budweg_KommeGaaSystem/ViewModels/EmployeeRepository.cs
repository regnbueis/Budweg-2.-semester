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

        //public void UpdateEmployeeBuildingId(int employeeId, int buildingId)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();

        //        //string query = "UPDATE EMPLOYEE SET BuildingId = @BuildingId WHERE EmployeeId = @EmployeeId";
        //        string query = "EXEC spUpdateEmployeeBuilding @EmployeeId = @EmployeeId, @BuildingId = @BuildingId";
        //        SqlCommand cmd = new SqlCommand(query, con);

        //        cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
        //        cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;

        //        int affectedRows = cmd.ExecuteNonQuery();
        //        if (affectedRows > 0)
        //        {
        //            Employee? employee = employees
        //                .Find(x => x.EmployeeId == employeeId);

        //        }
        //    }
        //}
    }
}
