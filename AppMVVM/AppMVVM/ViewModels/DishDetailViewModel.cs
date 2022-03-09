using AppMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppMVVM.ViewModels
{
    public class DishDetailViewModel : BaseViewModel
    {
        // Variables locales
        private readonly DishViewModel DishViewModel;
        
        // Comandos
        private Command _DeleteCommand;
        public Command DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new Command(DeleteAction));

        private Command _SaveCommand;

        public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        // Propiedades
        private int _DishID;
        public int DishID 
        {
            get => _DishID;
            set => SetProperty(ref _DishID, value); //set { SetProperty(ref _DishID, value); }
        }

        private string _DishName;
        public string DishName 
        {
            get => _DishName;
            set => SetProperty(ref _DishName, value);
        }

        private float _DishPrice;
        public float DishPrice
        {
            get => _DishPrice;
            set => SetProperty(ref _DishPrice, value);
        }

        private string _DishCategory;
        public string DishCategory
        {
            get => _DishCategory;
            set => SetProperty(ref _DishCategory, value);
        }

        private string _DishPicture;
        public string DishPicture
        {
            get => _DishPicture;
            set => SetProperty(ref _DishPicture, value);
        }

        // Constructor
        public DishDetailViewModel(DishViewModel dishViewModel)
        {
            this.DishViewModel = dishViewModel;
        }

        public DishDetailViewModel(DishViewModel dishViewModel, DishModel dish)
        {
            this.DishViewModel = dishViewModel;

            // Cargamos los datos del platillo seleccionado en los controles

            // Primera opcion
            DishID = dish.ID;
            DishName = dish.Name;
            DishCategory = dish.Category;
            DishPicture = dish.Picture;
            DishPrice = dish.Price;

            // Segunda opcion
            /*DishID = this.DishViewModel.SelectedDish.ID;
            DishName = this.DishViewModel.SelectedDish.Name;
            DishCategory = this.DishViewModel.SelectedDish.Category;
            DishPicture = this.DishViewModel.SelectedDish.Picture;
            DishPrice = this.DishViewModel.SelectedDish.Price;*/
        }

        // Métodos y procedimientos
        private void SaveAction(object obj)
        {
            if (DishID == 0)
            {
                // Crear
                int newID = this.DishViewModel.MemoryDishes.Count + 1;
                this.DishViewModel.MemoryDishes.Add(new DishModel
                    {
                        ID = newID,
                        Name = DishName,
                        Price = DishPrice,
                        Category = DishCategory,
                        Picture = DishPicture
                    });
            }
            else
            {
                // Actualizar
                foreach(DishModel dish in this.DishViewModel.MemoryDishes)
                {
                    if (dish.ID == DishID)
                    {
                        dish.Name = DishName;
                        dish.Price = DishPrice;
                        dish.Category = DishCategory;
                        dish.Picture = DishPicture;
                        break;
                    }
                }
            }

            // Refrescamos nuestro listado
            this.DishViewModel.ListRefresh();

            // Regresamos a nuestro listado
            Application.Current.MainPage.Navigation.PopAsync();
        }
        
        private void DeleteAction(object obj)
        {
            throw new NotImplementedException();
        }

    }
}
