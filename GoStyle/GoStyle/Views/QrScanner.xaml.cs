using GoStyle.Models;
using GoStyle.Services;
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
    public partial class QrScanner : ContentPage
    {
        public QrScanner()
        {
            InitializeComponent();
        }
        public void scanView_OnScanResult(ZXing.Result result)
        {

            /*ReductionServices reductionServices = ReductionServices.GetInstance();
            Reduction reduction = reductionServices.GetReductionAsync(result.Text).Result;
            Console.WriteLine(reduction.nom);*/

            UserService.getInstance().Connexion("","");
            Device.BeginInvokeOnMainThread(async () =>
            {

                await DisplayAlert("Scanned Result", result.Text, "OK");

            });

        }
    }
}