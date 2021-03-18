using GoStyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoStyle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel();
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
                DisplayAlert("Champs non remplie(s)", "Veuillez remplir tous les champs", "OK");
            else
            {
                DisplayAlert("Inscription réussi !", "Vous êtes bien inscrit", "OK");
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}