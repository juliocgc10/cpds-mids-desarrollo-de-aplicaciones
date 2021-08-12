using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFReg.ViewModels;

namespace XFReg.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityLog : ContentPage
    {
        public ActivityLog()
        {
            InitializeComponent();
            this.BindingContext = new ActivityLogViewModel();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}