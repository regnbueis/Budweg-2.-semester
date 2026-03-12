using Budweg_KommeGaaSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Windows.Input;

namespace Budweg_KommeGaaSystem.Command
{
    public class CheckOutCommand : ICommand
    {
        private readonly RegistrationRepository _registrationRepo;

        public CheckOutCommand(RegistrationRepository registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if (parameter is MainViewModel mvm)
            {
                if (!string.IsNullOrWhiteSpace(mvm.EmployeeToCheckInOut))
                {
                    if (mvm.SelectedBuilding != null)
                    {
                        if (int.TryParse(mvm.EmployeeToCheckInOut, out int employeeId))
                        {
                            if (_registrationRepo.IsEmployeeCheckedIn(employeeId))
                            {
                                result = true;
                            }
                        }
                    }
                }
            }

            CommandManager.InvalidateRequerySuggested();
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                if (int.TryParse(mvm.EmployeeToCheckInOut, out int employeeId))
                {
                    _registrationRepo.UpdateEmployeeDeparture(employeeId);
                    mvm.LoadEmployeeInBuilding();
                }
            }
        }
    }
}
