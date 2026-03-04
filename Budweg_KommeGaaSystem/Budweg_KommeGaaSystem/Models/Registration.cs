using System;
using System.Collections.Generic;
using System.Text;

namespace Budweg_KommeGaaSystem.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime? Departure { get; set; }

        public int EmployeeId { get; set; }
        public int BuildingId { get; set; }
    }
}
