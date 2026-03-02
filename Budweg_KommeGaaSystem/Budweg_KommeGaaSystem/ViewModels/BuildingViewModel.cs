using System;
using System.Collections.Generic;
using System.Text;
using Budweg_KommeGaaSystem.Models;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class BuildingViewModel
    {
        private Building building;
        public string BuildingName { get { return building.BuildingName; } }

        public BuildingViewModel(Building building)
        {
            this.building = building;
        }
    }
}
