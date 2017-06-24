using Xamarin.Forms;
using Expire.Views;
using Expire.ViewModels;

namespace Expire
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private static MainViewModel _mainViewModel = new MainViewModel();
        public static MainViewModel MainViewModel => _mainViewModel;
    }
}
