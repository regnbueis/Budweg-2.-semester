using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budweg_KommeGaaSystem
{
    internal static class Configuration
    {
        private static IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        public static string ConnectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
    }
}
