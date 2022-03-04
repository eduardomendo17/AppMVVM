using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppMVVM.ViewModels
{
    public class DishDetailViewModel : BaseViewModel
    {
        // Comandos
        private Command _DeleteCommand;
        public Command DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new Command(DeleteAction));

        private void DeleteAction(object obj)
        {
            throw new NotImplementedException();
        }

        private Command _SaveCommand;
        public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        private void SaveAction(object obj)
        {
            throw new NotImplementedException();
        }

        // Propiedades

        // Constructor
        public DishDetailViewModel()
        { }

        // Métodos y procedimientos
    }
}
