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

            InitializeComponent();

            var dateTime = DateTime.Now.AddDays(3);

            var ting2 = GetData(dateTime);
            BindingContext = new MainPageViewModel();


        }

        public async Task<SolarLunarName.Standard.Models.SolarLunarName> GetData(DateTime dateTime) {
            var DBPath = await DependencyService.Get<IFileAccessHelper>().GetDBPathAndCreateIfNotExists();
            var di = new DateInterpreter();
            var sln= await di.GetSolarLunarNameAsync(dateTime, DBPath);

            await DisplayAlert("Hello", sln.ToString(), "Bye");

            return sln;

        }


        void CalculateSolarLunarDate(object sender, EventArgs args)
        {
            //await GetData((DateTime)sender);
        }

        async void OnDatePickerValueChanged(object sender, ValueChangedEventArgs args)
        {
            await GetData(((DatePicker)sender).Date);
        }

    }
}
