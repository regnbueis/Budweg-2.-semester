using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Budweg_KommeGaaSystem.Models;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class MainViewModel
    {
        private BuildingRepository buildingRepo;
        private EmployeeRepository employeeRepo;

        public ObservableCollection<BuildingViewModel> BuildingsVM { get; set; }
        public ObservableCollection<EmployeeViewModel> EmployeesVM { get; set; }

        private BuildingViewModel selectedBuilding;
        public BuildingViewModel SelectedBuilding
        {
            get { return selectedBuilding; }
            set 
            { 
                selectedBuilding = value;
                OnPropertyChanged("SelectedBuilding");
                LoadEmployeeInBuilding();
            }
        }

        public MainViewModel()
        {
            buildingRepo = new BuildingRepository();
            employeeRepo = new EmployeeRepository();
            BuildingsVM = new ObservableCollection<BuildingViewModel>();
            EmployeesVM = new ObservableCollection<EmployeeViewModel>();

            foreach (Building building in buildingRepo.GetAll())
            {
                BuildingsVM.Add(new BuildingViewModel(building));
            }
        }


        public void LoadEmployeeInBuilding()
        {
            

            EmployeesVM.Clear();
            foreach (Employee employee in employeeRepo.RetrieveEmployeesByBuildingId(SelectedBuilding.BuildingId))
            {
                EmployeesVM.Add(new EmployeeViewModel(employee));
            }
        }








        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
