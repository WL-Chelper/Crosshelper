﻿using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class HelperProfilePage : ContentPage
    {
        IList<ReviewLabelContent> Helpers;

        public HelperProfilePage()
        {
            InitializeComponent();
        }

        public HelperProfilePage(HelperLabel hl)
        {
            InitializeComponent();
            HelperName.Text = hl.Name;
        }


        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        //Top Ring&Menu button
        void NHPPBackButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void NHPPCancelButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //Confirm
        void NHPPConfirm(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new SignInPage()));
        }
    }
}
