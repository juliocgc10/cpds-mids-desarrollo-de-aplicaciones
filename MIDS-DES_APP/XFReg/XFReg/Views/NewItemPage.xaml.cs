using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFReg.Models;
using XFReg.ViewModels;

namespace XFReg.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}