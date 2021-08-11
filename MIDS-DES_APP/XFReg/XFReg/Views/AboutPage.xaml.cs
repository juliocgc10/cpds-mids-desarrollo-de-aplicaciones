using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFReg.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            //this.txtEmail.Text = Preferences.Get("UserEmail", "No establecido");
            Task.Run(async () =>
                {
                    this.txtEmail.Text = await SecureStorage.GetAsync("UserEmail");
                    this.txtPhoneNumber.Text = await SecureStorage.GetAsync("UserPhoneNumber");
                    this.txtPassowrd.Text = await SecureStorage.GetAsync("UserPassword");
                }
            );
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await SecureStorage.SetAsync("UserEmail", txtEmail.Text);
            await SecureStorage.SetAsync("UserPhoneNumber", txtPhoneNumber.Text);
            await SecureStorage.SetAsync("UserPassword", txtPassowrd.Text);

            await this.DisplayAlert("Registro", "Los datos se guardaran", "Aceptar");
        }
    }
}