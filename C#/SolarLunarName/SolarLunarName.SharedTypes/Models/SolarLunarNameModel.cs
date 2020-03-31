using System;
using SolarLunarName.SharedTypes.Constants;
using SolarLunarName.SharedTypes.Exceptions;

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

                ValidationHelper<YearOutOfRangeException>(value.Year, Ranges.Year);
                _solarDateTime = value;
                
            } 
        }
    }


}