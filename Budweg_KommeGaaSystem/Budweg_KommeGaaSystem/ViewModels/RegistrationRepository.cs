using System.Data;
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
                .Where(x => x.Departure == null)
                .ToList();
        }

        public void CreateEmployeeArrival(int employeeId, int buildingId)
        {
            Registration reg = new Registration();
            DateTime temp = DateTime.Now;

            using (SqlConnection con = new SqlConnection (connectionString))
            {
                con.Open();
                string query = "EXEC spCreateEmployeeArrival @arrival = @Arrival, @employeeId = @EmployeeId, @buildingId = @BuildingId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@Arrival", SqlDbType.DateTime2).Value = temp;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                    cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;
                    
                    reg.RegistrationId = Convert.ToInt32(cmd.ExecuteScalar());
                    reg.Arrival = temp;
                    reg.BuildingId = buildingId;
                    reg.EmployeeId = employeeId;
                }
            }

            registrations.Add(reg);
        }
        
        public void UpdateEmployeeDeparture(Registration reg)
        {
            DateTime temp = DateTime.Now;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE REGISTRATION SET Departure = @Departure " +
                    "WHERE EmployeeID = @EmployeeId";
                
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@Departure", SqlDbType.DateTime2).Value = temp;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = reg.EmployeeId;
                    cmd.ExecuteNonQuery();
                }
            }

            reg.Departure = temp;
        }
    }
}
