﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PromotionCodePage : ContentPage
    {
        void Handle_AddPromotionCode(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        public PromotionCodePage()
        {
            InitializeComponent();
        }
    }
}
