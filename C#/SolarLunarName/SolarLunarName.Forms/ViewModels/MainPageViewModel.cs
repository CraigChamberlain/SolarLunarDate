using SolarLunarName.Standard.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SolarLunarName.Forms.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        DateTime dateTime;

        public event PropertyChangedEventHandler PropertyChanged;

        string solarLunarName;

        public MainPageViewModel()
        {
            this.dateTime = DateTime.Now;


        }

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;
                    CalculateSolarLunarName();


                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
            get
            {
                return dateTime;
            }
        }

        public string SolarLunarName
        {
            set
            {
                if (solarLunarName != value)
                {
                    solarLunarName = value;



                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SolarLunarName"));
                    }
                }
            }
            get
            {
                return solarLunarName;
            }
        }

        async void CalculateSolarLunarName()
        {
            var DBPath = await DependencyService.Get<IFileAccessHelper>().GetDBPathAndCreateIfNotExists();
            var di = new DateInstantiator();
            var sln = di.GetSolarLunarName(DateTime);

            SolarLunarName = sln.ToString();

        }


    }




}
