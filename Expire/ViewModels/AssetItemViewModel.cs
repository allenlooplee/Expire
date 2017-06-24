using System;
using System.Windows.Input;
using Expire.PersistenceModels;
using Xamarin.Forms;
using Realms;

namespace Expire.ViewModels
{
    public class AssetItemViewModel : ViewModelBase
    {
        public AssetItemViewModel()
        {
            Title = "新建";

            _model = new AssetItem();
            StartDate = DateTime.Today;
            EndDate = StartDate.AddYears(1);
        }

        public AssetItemViewModel(AssetItem model)
        {
            Title = "编辑";

            _model = model;
            Name = _model.Name;
            Price = Convert.ToDecimal(_model.Price);
            StartDate = _model.StartDate.Date;
            EndDate = _model.EndDate.Date;
            Remark = _model.Remark;
        }

        public string Title
        {
            get;
            private set;
        }

        private string _name;
        public string Name
		{
            get => _name;
			set
			{
				if (_name != value)
				{
					_name = value;
					RaisePropertyChanged();
				}
			}
		}

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("AverageValue");
                }
            }
        }

        private DateTime _startDate;
		public DateTime StartDate
		{
			get => _startDate;
			set
			{
				if (_startDate != value)
				{
					_startDate = value;
					RaisePropertyChanged();
                    RaisePropertyChanged("ElapsedDays");
                    RaisePropertyChanged("TotalDays");
                    RaisePropertyChanged("ElapsedRate");
                    RaisePropertyChanged("AverageValue");
				}
			}
		}

        private DateTime _endDate;
		public DateTime EndDate
		{
			get => _endDate;
			set
			{
				if (_endDate != value)
				{
					_endDate = value;
					RaisePropertyChanged();
					RaisePropertyChanged("TotalDays");
					RaisePropertyChanged("ElapsedRate");
					RaisePropertyChanged("AverageValue");
				}
			}
		}

        private string _remark;
		public string Remark
		{
			get => _remark;
			set
			{
				if (_remark != value)
				{
					_remark = value;
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
            get
            {
                return new Command(() => 
                {
                    var db = Realm.GetInstance();

                    if (Title == "新建")
                    {
                        db.Write(() =>
                        {
                            CopyValuesTo(_model);
                            db.Add(_model);
                        });

                        App.MainViewModel.AssetList.Add(this);
                    }
                    else
                    {
						db.Write(() =>
						{
                            CopyValuesTo(_model);
						});
                    }
                });
            }
		}

		public ICommand RemoveCommand
		{
            get
            {
                return new Command(() =>
                {
                    var db = Realm.GetInstance();
                    db.Write(() =>
                    {
                        db.Remove(_model);
                    });

                    App.MainViewModel.AssetList.Remove(this);
                });
            }
		}

        private void CopyValuesTo(AssetItem target)
        {
			target.Name = Name;
			target.Price = Convert.ToDouble(Price);
			target.StartDate = StartDate;
			target.EndDate = EndDate;
			target.Remark = Remark;
        }

        private AssetItem _model;
    }
}
