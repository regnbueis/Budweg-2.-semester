using System;
using System.Collections.Generic;
using System.Text;
using Budweg_KommeGaaSystem.Models;

namespace Budweg_KommeGaaSystem.ViewModels
{
    public class RegistrationViewModel
    {
        private Registration _registration;

        public DateTime Arrival
        {
            get { return _registration.Arrival; }
        }
        public RegistrationViewModel(Registration reg)
        {
            _registration = reg;
        }
    }
}
