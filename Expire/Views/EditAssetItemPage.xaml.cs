using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Expire.Views
{
    public partial class EditAssetItemPage : ContentPage
    {
        public EditAssetItemPage()
        {
            InitializeComponent();
        }

        async void SaveButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
