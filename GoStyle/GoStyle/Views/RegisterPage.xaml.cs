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
            // vérification que tous les champs soit bien remplis
            if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(Nom.Text) || string.IsNullOrEmpty(Prenom.Text) || string.IsNullOrEmpty(Numero.Text)) 
                DisplayAlert("Champs non remplie(s)", "Veuillez remplir tous les champs", "OK");
            else
            {
                // Message de validation de l'inscription
                DisplayAlert("Inscription réussi !", "Vous êtes bien inscrit", "OK");
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}