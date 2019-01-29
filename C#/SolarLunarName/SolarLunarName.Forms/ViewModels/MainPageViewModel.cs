using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SolarLunarName.Forms.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        DateTime dateTime;
        DateTime MinDate = new DateTime(1700, 1, 1);
        DateTime MaxDate = new DateTime(2083, 1, 1);

        public event PropertyChangedEventHandler PropertyChanged;

        string SolarLunarName { get; set;}

        public MainPageViewModel()
        {
            this.dateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

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


    }


}
