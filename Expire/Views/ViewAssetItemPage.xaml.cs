using System;
using System.Collections.Generic;
using Expire.ViewModels;

using Xamarin.Forms;

namespace Expire.Views
{
    public partial class ViewAssetItemPage : ContentPage
    {
        public ViewAssetItemPage()
        {
            InitializeComponent();
        }

        private void EditButton_Clicked(object sender, System.EventArgs e)
        {
            var targetPage = new EditAssetItemPage()
            {
                BindingContext = this.BindingContext
            };

            Navigation.PushAsync(targetPage);
        }
    }
}
