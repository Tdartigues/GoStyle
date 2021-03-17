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
            //Reduction reduction = ReductionServices.GetReductionServices().GetReductionAsync(result.Text).Result;
            ReductionServices reductionServices = ReductionServices.GetReductionServices();
            Reduction reduction = reductionServices.GetReductionAsync(result.Text).Result;
            Console.WriteLine(reduction.nom);

            Device.BeginInvokeOnMainThread(async () =>
            {

                await DisplayAlert("Scanned Result", reduction.nom, "OK");


                //DisplayAlert("Scanned Result", reduction.nom, "OK");
            });
        }
    }
}