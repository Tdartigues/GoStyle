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
        bool i;
        public QrScanner()
        {
            InitializeComponent();
            if(UserService.getInstance().getUser() is null)
            {
                //Message, vous etes pas co, Retour page d'acceuil
            }
            i = false;
        }
        public void scanView_OnScanResult(ZXing.Result result)
        {
            if (!i)
            {
                i = true;
                ReductionServices reductionServices = ReductionServices.GetInstance();
                Reduction reduction = reductionServices.GetReductionAsync(result.Text).Result;
                if (reduction is null)
                {
                    i = false;
                }
                else
                {
                    reductionServices.GetReductions().Add(reduction);
                    i = false;
                    Navigation.PushAsync(new ReducPage());
                }
                
            }
        }
    }
}