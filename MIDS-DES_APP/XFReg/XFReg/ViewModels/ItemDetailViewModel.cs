using Acr.UserDialogs;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFReg.Entities;
using XFReg.Models;

namespace XFReg.ViewModels
{
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
    [QueryProperty(nameof(EmployeeNumber), nameof(EmployeeNumber))]
    public class ItemDetailViewModel : BaseViewModel
    {
        #region Atributos
        private string itemId;
        private string text;
        private string description;
        public string Id { get; set; }

        private int employeeNumber;
        private Employee employee;

        private Boolean isEntryVisible;
        private Boolean isLabelVisible;

        private string originalEmployee;
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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public int EmployeeNumber
        {
            get => employeeNumber;

            set
            {
                employeeNumber = value;
                LoadEmployeeNumber(value);
            }
        }

        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;
                OnPropertyChanged();
            }
        }

        public bool IsEntryVisible
        {
            get => isEntryVisible;
            set
            {
                isEntryVisible = value;
                OnPropertyChanged();
            }
        }
        public bool IsLabelVisible
        {
            get => isLabelVisible;
            set
            {
                isLabelVisible = value;
                OnPropertyChanged();
            }

        }
        #endregion

        #region Commands
        public Command EditEmployeeCommand { get; set; }
        public Command CancelEditEmployeeCommand { get; set; }
        public Command SaveEditEmployeeCommand { get; set; }
        #endregion

        #region Contructors
        public ItemDetailViewModel()
        {
            base.Title = "Editar empleado";
            IsEntryVisible = false;
            IsLabelVisible = true;

            EditEmployeeCommand = new Command(OnEditEmployee);
            CancelEditEmployeeCommand = new Command(OnCancel);
            SaveEditEmployeeCommand = new Command(async () => await OnSaveEditEmployee());
        }



        #endregion
        #region Methods
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void LoadEmployeeNumber(int employeeNumber)
        {
            try
            {
                //var item = await DataStore.GetItemAsync(itemId);
                //Id = item.Id;
                //Text = item.Text;
                //Description = item.Description;

                HttpClient httpClient = new HttpClient();
                var result = await httpClient.GetAsync($"https://dev-app-mids.azurewebsites.net/api/Employee/{employeeNumber}");

                if (result.IsSuccessStatusCode)
                {
                    var webEmployee = await result.Content.ReadAsStringAsync();
                    originalEmployee = webEmployee;
                    Employee = JsonConvert.DeserializeObject<Employee>(webEmployee);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private void OnEditEmployee()
        {
            IsEntryVisible = true;
            IsLabelVisible = false;
            Employee = JsonConvert.DeserializeObject<Employee>(originalEmployee);
        }

        private void OnCancel()
        {
            IsEntryVisible = false;
            IsLabelVisible = true;

            Employee = JsonConvert.DeserializeObject<Employee>(originalEmployee);
            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
        }

        private async Task OnSaveEditEmployee()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage result = await httpClient.PutAsync("https://dev-app-mids.azurewebsites.net/api/Employee"
                , new StringContent(JsonConvert.SerializeObject(this.Employee), encoding: Encoding.UTF8, mediaType: "application/json"));

            if (result.IsSuccessStatusCode)
            {
                UserDialogs.Instance.Alert(new AlertConfig()
                {
                    Message = "Se actualizó el empleado correctamente",
                    OkText = "Aceptar",
                    Title = "Empelado actualziadodo"
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
                    Message = "No se actualizo correctamente",
                    OkText = "Aceptar",
                    Title = "Empleado no actualiado"
                });
            }
        }
        #endregion
    }
}
