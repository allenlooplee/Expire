using System;
using System.Collections.ObjectModel;
using System.Linq;
using Expire.Models;
using Xamarin.Forms;

namespace Expire.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            AssetList = new ObservableCollection<AssetItemViewModel>();

            var rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                var assetItem = new AssetItem();
				assetItem.Name = "Asset #" + i;
				assetItem.Price = Convert.ToDecimal(Math.Round(rand.NextDouble(), 4) * 100);
				assetItem.StartDate = DateTime.Today.AddDays(-i);
				assetItem.EndDate = assetItem.StartDate.AddYears(1);
				assetItem.Remark = "Remark for asset #" + i;

                var assetItemViewModel = new AssetItemViewModel(assetItem);
                assetItemViewModel.RemoveCommand = new Command(() => AssetList.Remove(assetItemViewModel));
                AssetList.Add(assetItemViewModel);
            }
        }

        public ObservableCollection<AssetItemViewModel> AssetList
        {
            get;
            private set;
        }
    }
}
