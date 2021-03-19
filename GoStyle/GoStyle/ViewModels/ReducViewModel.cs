using GoStyle.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoStyle.ViewModels
{
    public class ReducViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }

        public ReducViewModel()
        {
            RegisterCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}