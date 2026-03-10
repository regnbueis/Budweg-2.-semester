using System;
using System.Collections.Generic;
using System.Text;
using Budweg_KommeGaaSystem.Models;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class BuildingViewModel
    {
        private Building _building;
        
        public int BuildingId 
        { 
            get 
            { return _building.BuildingId; } 
            set { _building.BuildingId = value; } 
        }
        public string Name 
        { 
            get { return _building.BuildingName; } 
            set { _building.BuildingName = value; } 
        }

        public BuildingViewModel(Building building)
        {
            _building = building;
        }
    }
}
