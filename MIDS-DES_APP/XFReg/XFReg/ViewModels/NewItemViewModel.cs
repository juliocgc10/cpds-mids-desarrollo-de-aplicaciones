using Acr.UserDialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFReg.Entities;
using XFReg.Models;

namespace XFReg.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;


        #region Constructor
        public NewItemViewModel()
        {
            //SaveCommand = new Command(OnSave, ValidateSave);
            SaveCommand = new Command(async () => await OnSave());
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            Employee = new Employee()
            {
                Birthday = new DateTime(1989, 10, 8)
            };
        }

        #endregion


        #region Properties
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private Employee employee;

        public Employee Employee { get; set; }


        public Command SaveCommand { get; set; }
        public Command CancelCommand { get; set; }

        #endregion

        #region Methods
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async Task OnSave()
        {
            //Item newItem = new Item()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Text = Text,
            //    Description = Description
            //};

            //await DataStore.AddItemAsync(newItem);



            //UserDialogs.Instance.ShowLoading("TEST");
            //UserDialogs.Instance.Alert("hola", "print", "aceptar");
            //UserDialogs.Instance.Alert(new AlertConfig()
            //{
            //    Message = "Se agrego el empleado correctamente",
            //    OkText = "Aceptar",
            //    Title = "Empelado agregado"
            //});


            HttpClient httpClient = new HttpClient();
            HttpResponseMessage result = await httpClient.PostAsync("https://dev-app-mids.azurewebsites.net/api/Employee", new StringContent(JsonConvert.SerializeObject(this.Employee), encoding: Encoding.UTF8, mediaType: "application/json"));

            if (result.IsSuccessStatusCode)
            {
                UserDialogs.Instance.Alert(new AlertConfig()
                {
                    Message = "Se agrego el empleado correctamente",
                    OkText = "Aceptar",
                    Title = "Empelado agregado"
                });


                //    UserDialogs.Init(this);
                //OR UserDialogs.Init(() => provide your own top level activity provider)
                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                UserDialogs.Instance.Alert(new AlertConfig()
                {
                    Message = "No se agrego el empleado correctamente",
                    OkText = "Aceptar",
                    Title = "Empleado no agregado"
                });
            }



        }
        #endregion
    }
}
