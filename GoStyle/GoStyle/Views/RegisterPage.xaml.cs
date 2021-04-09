using GoStyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoStyle.Services;

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
        async Task RetourHomePage()
        {
            await Navigation.PopAsync();
        }
        async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            // vérification que tous les champs soit bien remplis
            if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(Nom.Text) || string.IsNullOrEmpty(Prenom.Text) || string.IsNullOrEmpty(Numero.Text)) 
                await DisplayAlert("Champs non remplie(s)", "Veuillez remplir tous les champs", "OK");
            else
            {
                if (UserService.getInstance().CreateUser(Email.Text, Password.Text, Prenom.Text, Nom.Text, Numero.Text))
                {
                    // Message de validation de l'inscription
                    await DisplayAlert("Inscription réussi !", "Vous êtes bien inscrit", "OK");
                    await RetourHomePage();
                }
                else
                {
                    await DisplayAlert("Une erreur est survenue", "Une erreur est survenue\nVeuillez contacter notre support", "OK");
                }
                
            }
        }
    }
}