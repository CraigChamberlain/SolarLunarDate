using SolarLunarName.Standard.ApplicationServices;
using System;
using System.Collections.Generic;
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
            var ting2 = new GetSolarLunarName(dateTime, "./MoonPhase.sqlite");

            string name = ting2.ToString();


        }
    }
}
