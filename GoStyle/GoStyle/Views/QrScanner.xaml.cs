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
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned Result", result.Text, "OK");

                //Reduction reduction = ReductionServices.GetReductionServices().GetReductionAsync(result.Text).Result;
                //DisplayAlert("Scanned Result", reduction.nom, "OK");
            });
            //Reduction reduction = ReductionServices.GetReductionServices().GetReductionAsync(result.Text).Result;
            ReductionServices reductionServices = ReductionServices.GetReductionServices();
            Reduction reduction = reductionServices.GetReductionAsync(result.Text).Result;
        }
    }
}