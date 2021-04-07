using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoStyle.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        var logoApp = new Image {
            Source = ImageSource.FromUri(
                new Uri("https://media.discordapp.net/attachments/799566225088577588/821362139226439680/GOSTYLE.PNG")
            ) };
        }

        //Réglage du bouton pour renvoyer sur la page d'inscription
        async void RedirectToRegisterPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        //Réglage du bouton pour renvoyer sur la page de connexion
        async void RedirectToLoginPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        //Réglage du bouton pour renvoyer sur la caméra
        async void RedirectToCamPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QrScanner());
        }

    }
}