using System;
using System.Windows.Input;
using Expire.Models;

namespace Expire.ViewModels
{
    public class AssetItemViewModel : ViewModelBase
    {
        public AssetItemViewModel()
        {
            _model = new AssetItem()
			{
				StartDate = DateTime.Today,
				EndDate = DateTime.Today.AddYears(1)
			};
            Title = "新建";
        }

        public AssetItemViewModel(AssetItem model)
        {
            _model = model;
            Title = "编辑";
        }

        public string Title
        {
            get;
            private set;
        }

        public string Name
		{
			get => _model.Name;
			set
			{
				if (_model.Name != value)
				{
					_model.Name = value;
					RaisePropertyChanged();
				}
			}
		}

        public decimal Price
        {
            get => _model.Price;
            set
            {
                if (_model.Price != value)
                {
                    _model.Price = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("AverageValue");
                }
            }
        }

		public DateTime StartDate
		{
			get => _model.StartDate;
			set
			{
				if (_model.StartDate != value)
				{
					_model.StartDate = value;
					RaisePropertyChanged();
                    RaisePropertyChanged("ElapsedDays");
                    RaisePropertyChanged("TotalDays");
                    RaisePropertyChanged("ElapsedRate");
                    RaisePropertyChanged("AverageValue");
				}
			}
		}

		public DateTime EndDate
		{
			get => _model.EndDate;
			set
			{
				if (_model.EndDate != value)
				{
					_model.EndDate = value;
					RaisePropertyChanged();
					RaisePropertyChanged("TotalDays");
					RaisePropertyChanged("ElapsedRate");
					RaisePropertyChanged("AverageValue");
				}
			}
		}

		public string Remark
		{
			get => _model.Remark;
			set
			{
				if (_model.Remark != value)
				{
					_model.Remark = value;
					RaisePropertyChanged();
				}
			}
		}

		public int ElapsedDays => (DateTime.Today - StartDate).Days;
		public int TotalDays => (EndDate - StartDate).Days;
		public double ElapsedRate => (double)ElapsedDays / TotalDays;
		public decimal AverageValue => Price / TotalDays;

		public ICommand SaveCommand
		{
			get;
			set;
		}

		public ICommand RemoveCommand
		{
			get;
			set;
		}

        protected AssetItem _model;
    }
}
