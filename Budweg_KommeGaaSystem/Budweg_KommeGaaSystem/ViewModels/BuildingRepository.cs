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

            buildings = InitializeRepo();

        }

        public List<Building> InitializeRepo()
        {
            List<Building> buildings = new List<Building>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT BuildingId, BuildingName FROM BUILDING", con);
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
            return buildings;
        }

        public List<Building> GetAll()
        {
            return buildings;
        }
    }
}
