using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFReg.Models;
using XFReg.ViewModels;
using XFReg.Views;

namespace XFReg.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            if ((this.BindingContext as ItemsViewModel).Employees.Count == 0)
            {
                _viewModel.IsBusy = true;
            }
        }

        private async void ViewLogActivities_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ActivityLog()));
        }
    }
}