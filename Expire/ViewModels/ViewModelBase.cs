using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Expire.Utils;

namespace Expire.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
		private string title = string.Empty;
		public string Title
		{
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}