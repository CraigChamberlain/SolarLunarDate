using SolarLunarName.Forms.ViewModels;
using SolarLunarName.Standard.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SolarLunarName.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var bindingContext = new MainPageViewModel();
            BindingContext = bindingContext;
            InitializeComponent();
            DatePicker.SetValue(DatePicker.MaximumDateProperty, new DateTime(2083, 1, 1));
            DatePicker.SetValue(DatePicker.MinimumDateProperty, new DateTime(1700, 1, 1));



        }



    }
}
