using System;
using System.Collections.ObjectModel;
using System.Linq;
using Expire.PersistenceModels;
using Xamarin.Forms;
using Realms;

namespace Expire.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Title = "资产列表";
            AssetList = new ObservableCollection<AssetItemViewModel>();

            var db = Realm.GetInstance();
            var assetItems = db.All<AssetItem>();
            foreach (var assetItem in assetItems)
            {
				var assetItemViewModel = new AssetItemViewModel(assetItem);
				AssetList.Add(assetItemViewModel);
            }

            // The below properties should notify changes
            // after the related asset item properties updates.
            NormalLoadAssetItemCount = AssetList.Count(arg => arg.EndDate >= DateTime.Today);
            OverloadAssetItemCount = AssetList.Count(arg => arg.EndDate < DateTime.Today);
            TodayTotalDepreciation = AssetList.Where(arg => arg.EndDate >= DateTime.Today).Sum(arg => arg.AverageDepreciation);
        }

        public ObservableCollection<AssetItemViewModel> AssetList
        {
            get;
            private set;
        }

        private AssetItemViewModel _selectedAssetItem;
        public AssetItemViewModel SelectedAssetItem
        {
            get => _selectedAssetItem;
            set => SetProperty(ref _selectedAssetItem, value);
        }

        public decimal TodayTotalDepreciation
        {
            get;
            set;
        }

        public int NormalLoadAssetItemCount
        {
            get;
            set;
        }

        public int OverloadAssetItemCount
        {
            get;
            set;
        }
    }
}
