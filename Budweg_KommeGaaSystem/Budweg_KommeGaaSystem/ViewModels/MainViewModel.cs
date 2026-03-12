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

        public ObservableCollection<BuildingViewModel> BuildingVMs { get; set; }
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

        private string employeeToCheckInOut;
        public string EmployeeToCheckInOut 
        { 
            get { return  employeeToCheckInOut; }
            set { employeeToCheckInOut = value; }
        }

        public MainViewModel()
        {
            buildingRepo = new BuildingRepository();
            employeeRepo = new EmployeeRepository();
            registrationRepo = new RegistrationRepository();

            BuildingVMs = new ObservableCollection<BuildingViewModel>();
            RegistrationVMs = new ObservableCollection<RegistrationViewModel>();

            foreach (Building building in buildingRepo.GetAll())
            {
                BuildingVMs.Add(new BuildingViewModel(building));
            }
        }


        public void LoadEmployeeInBuilding()
        {
            RegistrationVMs.Clear();
            
            List<Registration> registrations = registrationRepo.GetAllByBuildingId(SelectedBuilding.BuildingId);
            registrations.ForEach(registration =>
            {
                Employee? employee = employeeRepo.GetEmployeeById(registration.EmployeeId);

                if (employee != null)
                {
                    RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration, employee);
                    RegistrationVMs.Add(registrationViewModel);
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
