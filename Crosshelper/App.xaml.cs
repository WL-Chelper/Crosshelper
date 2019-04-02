﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Crosshelper.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Crosshelper
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NewcomerMyProfilePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
