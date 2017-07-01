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
            Navigation.PushAsync(new ViewAssetItemPage());
        }

        void MainPage_Appearing(object sender, System.EventArgs e)
        {
            App.MainViewModel.SelectedAssetItem = null;
        }
    }
}
