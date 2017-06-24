using System;
using System.Collections.ObjectModel;
using System.Linq;
using Expire.PersistenceModels;
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
				AssetList.Add(assetItemViewModel);
            }
        }

        public ObservableCollection<AssetItemViewModel> AssetList
        {
            get;
            private set;
        }

        public AssetItemViewModel SelectedAssetItem
        {
            get;
            set;
        } 
    }
}
