using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using PokemonAPI.Models;
using Xamarin.Forms;

namespace PokemonAPI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Results> Results { get; set; } = new ObservableCollection<Results>();
        
        public MainViewModel() : base("ChuckForms")
        {
            RefreshCommand = new Command(async () => await LoadData(), () => !IsBusy);
            ItemClickCommand = new Command<string>(async (item) => await ItemClickCommandExecuteAsync(item));
        }

        public override async Task Initialize(object parameters = null) => await LoadData();

        async Task ItemClickCommandExecuteAsync(string ulr)
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                var list = await Api.GetPokemon(ulr);
                var abl = "";

                foreach (var item in list)
                {
                    abl += $"{item.Ability.Name}";
                    abl += " - ";
                }
                await ShowAlertAsync("Abilitys", abl, "LOL");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                Pokemon pokemon = await Api.GetAllPokemon();

                Results.Clear();
                foreach (var pk in pokemon.Results)
                    Results.Add(pk);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }

    }
}
