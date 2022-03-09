using AppMVVM.Models;
using AppMVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppMVVM.ViewModels
{
    public class DishViewModel : BaseViewModel
    {
        // Variables locales
        public List<DishModel> MemoryDishes;

        // Deeclaración de comandos Binding
        private Command _LoadCommand;
        public Command LoadCommand => _LoadCommand ?? (_LoadCommand = new Command(LoadAction));

        private Command _NewCommand;
        public Command NewCommand => _NewCommand ?? (_NewCommand = new Command(NewAction));

        private Command _SelectedCommand;
        public Command SelectedCommand => _SelectedCommand ?? (_SelectedCommand = new Command(SelectedAction));

        /*public Command LoadCommand
        {
            get
            {
                if (_LoadCommand == null) _LoadCommand = new Command(LoadAction);
                return _LoadCommand;
            }
        }*/

        // Declaración de propiedades Binding
        private List<DishModel> _ListDishes;
        public List<DishModel> ListDishes 
        {
            get => _ListDishes;
            set => SetProperty(ref _ListDishes, value);
        }

        private DishModel _SelectedDish;
        public DishModel SelectedDish
        {
            get => _SelectedDish;
            set => SetProperty(ref _SelectedDish, value);
        }

        // Constructor
        public DishViewModel()
        {
            // Llenamos nuestra variable local con los platillos iniciales
            MemoryDishes = new List<DishModel>
            {
                new DishModel()
                {
                    ID = 1,
                    Category = "Ensalada",
                    Name = "Cesar",
                    Price = 60,
                    Picture = "https://static8.depositphotos.com/1004373/892/i/600/depositphotos_8920718-stock-photo-salad-with-vegetables-and-greens.jpg"
                },
                new DishModel()
                {
                    ID = 2,
                    Category = "Sopa",
                    Name = "Jugo de carne",
                    Price = 55,
                    Picture = "https://www.cocinavital.mx/wp-content/uploads/2017/11/jugo_de_carne.jpg"
                },
                new DishModel()
                {
                    ID= 3,
                    Category = "Postre",
                    Name = "Cheesecake",
                    Price = 45,
                    Picture = "https://thumbs.dreamstime.com/b/pastel-de-queso-de-la-fresa-22627364.jpg"
                }
            };
        }

        // Métodos y procedimientos
        private void LoadAction()
        {
            // Los platillos que tenemos en memoria los desplegamos en nuestro collectioview
            ListDishes = null;
            ListDishes = MemoryDishes;
        }

        private void NewAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new DishDetailView(this));
        }

        private void SelectedAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new DishDetailView(this, SelectedDish));
        }

        public void ListRefresh()
        {
            LoadAction();
        }
    }
}
