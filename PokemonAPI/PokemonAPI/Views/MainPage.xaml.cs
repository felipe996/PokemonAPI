using PokemonAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonAPI.Views
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel
        {
            get
            {
                if (BindingContext == null)
                    BindingContext = new MainViewModel();

                return (BindingContext as MainViewModel);
            }
        }

        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Initialize(null);
        }

        private void ListViewResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e != null && e.Item != null)
            {
                var teste = e.Item as Models.Results;
                ViewModel?.ItemClickCommand.Execute(teste.Url);
            }
        }
    }
}
