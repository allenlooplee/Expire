using System;
using System.Collections.Generic;
using Expire.ViewModels;
using Expire.Views;
using Xamarin.Forms;

namespace Expire.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        private void NewButton_Clicked(object sender, System.EventArgs e)
        {
            var targetPage = new EditAssetItemPage()
            {
                BindingContext = new AssetItemViewModel()
			};

			Navigation.PushAsync(targetPage);
        }

        private void ListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var targetPage = new ViewAssetItemPage()
            {
                BindingContext = e.Item
            };

            Navigation.PushAsync(targetPage);
        }
    }
}
