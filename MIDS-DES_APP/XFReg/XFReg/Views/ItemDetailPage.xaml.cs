using System.ComponentModel;
using Xamarin.Forms;
using XFReg.ViewModels;

namespace XFReg.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}