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
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if ( parameter is MainViewModel mvm)
            {
                if (mvm.EmployeeToCheckInOut != string.Empty)
                {
                    mvm.RegistrationVMs.Where(x => x.EmployeeId == int.TryParse(mvm.EmployeeToCheckInOut));
                }
            }
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
