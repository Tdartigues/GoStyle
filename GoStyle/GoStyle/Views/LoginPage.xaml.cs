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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        async Task RetourHomePage()
        {
            await Navigation.PopAsync();
        }

        async void Loginbutton_Clicked(object sender, EventArgs e)  
        {  
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text))
                await DisplayAlert("CHAMPS VIDE(S) !", "Entrez vos identifiants", "OK");  
            else  
            {  
                if (UserService.getInstance().Connexion(Email.Text,Password.Text))  
                {
                    await DisplayAlert("Login Success", "", "Ok");
                    //Navigate to Homepage after successfully login  
                    await RetourHomePage();
                }  
                else
                    await DisplayAlert("Login Error", "Entrez les bons identifiants", "OK");  
            }  
        }

        async void RedirectToRegisterPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}