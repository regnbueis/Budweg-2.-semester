using Budweg_KommeGaaSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Budweg_KommeGaaSystem.Command
{
    public class CheckInCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if (parameter is MainViewModel mvm)
            {
                if (mvm.EmployeeToCheckInOut != string.Empty)
                {
                    result = true;
                }
            }
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.CheckInEmployeeAdmin();
            }
        }
    }
}
