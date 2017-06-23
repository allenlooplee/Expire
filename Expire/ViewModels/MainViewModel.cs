using System;
using System.Collections.ObjectModel;
using System.Linq;
using Expire.Models;
using Xamarin.Forms;
using Realms;

namespace Expire.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            AssetList = new ObservableCollection<AssetItemViewModel>();

            var db = Realm.GetInstance();
            var assetItems = db.All<AssetItem>();
            foreach (var assetItem in assetItems)
            {
				var assetItemViewModel = new AssetItemViewModel(assetItem);
				assetItemViewModel.RemoveCommand = new Command(() => AssetList.Remove(assetItemViewModel));
				AssetList.Add(assetItemViewModel);
            }

            MessagingCenter.Subscribe<AssetItemViewModel>(
                this,
                "AssetItemCreated",
                sender => AssetList.Add(sender));
        }

        public ObservableCollection<AssetItemViewModel> AssetList
        {
            get;
            private set;
        }
    }
}
