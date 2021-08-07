using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFReg.Services;
using XFReg.Views;

namespace XFReg
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
