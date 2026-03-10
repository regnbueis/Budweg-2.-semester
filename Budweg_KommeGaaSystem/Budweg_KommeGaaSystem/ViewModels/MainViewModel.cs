using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Documents;
using Budweg_KommeGaaSystem.Models;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class MainViewModel
    {
        private BuildingRepository buildingRepo;
        private EmployeeRepository employeeRepo;
        private RegistrationRepository registrationRepo;

        public ObservableCollection<BuildingViewModel> BuildingsVMs { get; set; }
        public ObservableCollection<EmployeeViewModel> EmployeesVMs { get; set; }
        public ObservableCollection<RegistrationViewModel> RegistrationVMs { get; set; }

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

        private string employeeToCheckIn;
        public string EmployeeToCheckIn 
        { 
            get { return  employeeToCheckIn; }
            set
            {
                employeeToCheckIn = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    CheckInEmployeeAdmin();
                    LoadEmployeeInBuilding();
                    EmployeeToCheckIn = string.Empty;
                    OnPropertyChanged("EmployeeToCheckIn");
                    
                }
            }
        }

        public MainViewModel()
        {
            buildingRepo = new BuildingRepository();
            employeeRepo = new EmployeeRepository();
            registrationRepo = new RegistrationRepository();

            BuildingsVMs = new ObservableCollection<BuildingViewModel>();
            EmployeesVMs = new ObservableCollection<EmployeeViewModel>();

            foreach (Building building in buildingRepo.GetAll())
            {
                BuildingsVMs.Add(new BuildingViewModel(building));
            }
        }


        public void LoadEmployeeInBuilding()
        {
            EmployeesVMs.Clear();

            List<Registration> registrations = registrationRepo.GetAllByBuildingId(SelectedBuilding.BuildingId);
            registrations.ForEach(registration =>
            {
                Employee? employee = employeeRepo.GetEmployeeById(registration.EmployeeId);
                
                if (employee != null)
                {
                    EmployeesVMs.Add(new EmployeeViewModel(employee));
                }
            });
        }

        public void CheckInEmployeeAdmin()
        {
            //employeeRepo.UpdateEmployeeBuildingId(int.Parse(EmployeeToCheckIn), 1);
        }








        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
