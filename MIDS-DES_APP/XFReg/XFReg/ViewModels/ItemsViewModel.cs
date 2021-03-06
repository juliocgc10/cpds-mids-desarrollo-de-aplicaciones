using Acr.UserDialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XFReg.Entities;
using XFReg.Models;
using XFReg.Views;

namespace XFReg.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;
        private Employee _selectedEmployee;
        private ObservableCollection<Employee> employees;
        #region Properties        
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged();
            }

        }
        public Command LoadEmployeesCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public Command DeleteEmployeeCommand { get; }
        public Command EditEmployeeCommand { get; }
        public Command CallEmployeeCommand { get; }
        public Command SendEmailEmployeeCommand { get; }
        #endregion

        #region Constructors
        public ItemsViewModel()
        {
            Title = "Empleados";
            Employees = new ObservableCollection<Employee>();
            LoadEmployeesCommand = new Command(async () => await ExecuteLoadEmployeesCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            DeleteEmployeeCommand = new Command(async (emp) => await DeleteEmployee((Employee)emp));
            EditEmployeeCommand = new Command<Employee>(OnEditEmployee);
            CallEmployeeCommand = new Command<Employee>(async (emp) => await OnCallEmployee(emp));
            SendEmailEmployeeCommand = new Command<Employee>(async (emp) => await OnSendEmailEmployee(emp));
        }






        #endregion

        private async Task ExecuteLoadEmployeesCommand()
        {
            IsBusy = true;

            try
            {
                Employees.Clear();

                HttpClient httpClient = new HttpClient();
                var result = await httpClient.GetAsync("https://dev-app-mids.azurewebsites.net/api/Employee");

                if (result.IsSuccessStatusCode)
                {
                    var webEmployees = await result.Content.ReadAsStringAsync();
                    Employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(webEmployees);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task OnCallEmployee(Employee obj)
        {
            var confirm = new ConfirmConfig()
            {
                Message = $"¿Está seguro de llamar a {obj.FullName}",
                Title = $"Llamar a {obj.FullName}",
                OkText = "Aceptar",
                CancelText = "cancelar"
            };

            var result = await UserDialogs.Instance.ConfirmAsync(confirm);
            if (result)
            {
                await Launcher.OpenAsync(new Uri($"tel:{obj.PhoneNumber}"));
            }

        }

        private async Task OnSendEmailEmployee(Employee obj)
        {
            var confirm = new ConfirmConfig()
            {
                Message = $"¿Está seguro de enviar un correo a {obj.FullName}",
                Title = $"Enviar correo a {obj.FullName}",
                OkText = "Aceptar",
                CancelText = "cancelar"
            };
            
            var result = await UserDialogs.Instance.ConfirmAsync(confirm);
            if (result)
            {
                EmailMessage msg = new EmailMessage()
                {
                    Subject = "Correo de prueba",
                    Body = "Este es un correo de prueba desde xamarin",
                    To = new List<string>() { obj.Email },

                };
                await Email.ComposeAsync(msg);
            }
        }

        private void OnActionconfirm(bool obj)
        {
            if (obj)
            {

            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }


        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                SetProperty(ref _selectedEmployee, value);
                OnEditEmployee(value);
            }
        }



        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        private async void OnEditEmployee(Employee obj)
        {
            if (obj == null)
            {
                return;
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.EmployeeNumber)}={obj.EmployeeNumber}");
            //await Shell.Current.GoToAsync(new ItemDetailPage(new ItemDetailViewModel(obj)));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }



        private async Task DeleteEmployee(Object employee)
        {

            HttpClient httpClient = new HttpClient();
            var result = await httpClient.DeleteAsync($"https://dev-app-mids.azurewebsites.net/api/Employee/{(employee as Employee).EmployeeNumber}");

            if (result.IsSuccessStatusCode)
            {
                await ExecuteLoadEmployeesCommand();

                UserDialogs.Instance.Alert(new AlertConfig()
                {
                    Message = "Se elimino correctamente",
                    OkText = "Aceptar",
                    Title = "Empleado eliminado"
                });

            }
            else
            {
                UserDialogs.Instance.Alert(new AlertConfig()
                {
                    Message = "No se elimino correctamente",
                    OkText = "Aceptar",
                    Title = "Empleado no eliminado"
                });
            }
        }
    }
}