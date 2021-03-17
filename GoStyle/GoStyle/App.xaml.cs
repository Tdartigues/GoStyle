﻿using GoStyle.Services;
using GoStyle.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoStyle
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new QrScanner();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
