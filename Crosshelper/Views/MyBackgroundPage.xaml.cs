﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Crosshelper.Models;
using Crosshelper.Helpers;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBackgroundPage : ContentPage
    {
        void Handle_Saved(object sender, System.EventArgs e)
        {
            _usr.FLanguage = FLanguage;
            _usr.SLanguage = SLanguage;
            uih.UpdateUserInfo(_usr);
            Navigation.PopAsync(false);
        }
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }

        UserInfoHelper uih = new UserInfoHelper();
        public IList LanguageItems { get; }
        //Homeland
        //public ObservableCollection<HomeLandPickerItem> HomeLandItemsSource { get; } = new ObservableCollection<HomeLandPickerItem>();
        //public ObservableCollection<HomeLandPickerItem> HomeLandSelectedItems { get; set; } = new ObservableCollection<HomeLandPickerItem>();

        public string FLanguage { get; set; }
        public string SLanguage { get; set; }

        User _usr;

        public MyBackgroundPage(User user)
        {
            InitializeComponent();

            _usr = user;

            FLanguage = user.FLanguage;
            SLanguage = user.SLanguage;

            List<string> list = new List<string>
            {
                "Chinese",
                "English",
                "Spanish",
                "Korean",
                "Japanese",
                "French",
                "German",
                "Thai"
            };
            LanguageItems = list;

            BindingContext = this;
        }

        public class HomeLandPickerItem
        {
            public string Name { get; set; }
        }
    }
}
