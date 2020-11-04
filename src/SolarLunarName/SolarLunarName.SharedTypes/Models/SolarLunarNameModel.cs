using System;

namespace SolarLunarName.SharedTypes.Models
{
    public class SolarLunarNameModel: SolarLunarNameSimple
    {   
        
        public SolarLunarNameModel(DateTime solarDateTime, int year, int lunarMonth, int lunarDay)
            :base(year, lunarMonth, lunarDay)
        {
        SolarDateTime = solarDateTime;
        }

        private DateTime _solarDateTime;
        
        public DateTime SolarDateTime {

            get {
                return _solarDateTime ;
                }
            set {

                Validation.Helpers.ValidateYear(value.Year);
                _solarDateTime = value;
                
            } 
        }
    }


}