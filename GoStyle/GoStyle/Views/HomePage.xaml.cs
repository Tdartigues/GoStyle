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

        async void RedirectToRegisterPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        async void RedirectToLoginPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

    }
}