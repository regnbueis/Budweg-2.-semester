using System;
using System.Collections.Generic;
using System.Text;
using Budweg_KommeGaaSystem.Models;
using Microsoft.Data.SqlClient;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class BuildingRepository
    {
        private readonly string connectionString;
        private List<Building> buildings;

        public BuildingRepository()
        {
            connectionString = Configuration.ConnectionString;

            buildings = new List<Building>();
            InitializeRepository();
        }

        public void InitializeRepository()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                
                string query = "SELECT BuildingId, BuildingName FROM BUILDING";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Building building = new Building()
                        {
                            BuildingId = dr.GetInt32(0),
                            BuildingName = (string)dr["BuildingName"]
                        };

                        buildings.Add(building);
                    }
                }
            }
        }

        public List<Building> GetAll()
        {
            return buildings;
        }
    }
}
