using GoStyle.ViewModels;
using GoStyle.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoStyle.Models;
using GoStyle.Services;
namespace GoStyle.Views
{
    public partial class ReducPage : ContentPage
    {
        public ReducPage()
        {
            InitializeComponent();
            BindingContext = new ReducViewModel();
            ReducionView.ItemsSource = ReductionServices.GetInstance().GetReductions();
        }
    }
}