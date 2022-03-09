using AppMVVM.Models;
using AppMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DishDetailView : ContentPage
    {
        public DishDetailView(DishViewModel dishViewModel)
        {
            InitializeComponent();

            BindingContext = new DishDetailViewModel(dishViewModel);
        }

        public DishDetailView(DishViewModel dishViewModel, DishModel dish)
        {
            InitializeComponent();

            BindingContext = new DishDetailViewModel(dishViewModel, dish);
        }
    }
}