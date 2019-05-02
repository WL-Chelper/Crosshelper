﻿using System;
using System.Collections.Generic;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PickHelperPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new NewcomerHelperProfilePage());
        }

        IList<UserPro> Helpers;
        UserProListHelper listhelper = new UserProListHelper();
        BindingContextConverter cvt = new BindingContextConverter();
        // Color statuscolor = new Color();//(79B563);
        public PickHelperPage()
        {
            InitializeComponent();
            listhelper.GetProHelperByTag(1);
            listhelper.SearchingInit();
            Helpers = cvt.BindingHelpersConvert(listhelper.Helperlist);
            /*
            Helpers.Add(new HelperLabel
            {
                Name = "Baboon",
                Bornin = "China",
                Rating = "★★★★★",
                Language = "Language: Chinese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });*/
            BindingContext = this;
        }
    }
}
