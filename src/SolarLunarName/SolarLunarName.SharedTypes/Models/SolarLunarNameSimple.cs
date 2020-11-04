using SolarLunarName.SharedTypes.Validation;

namespace SolarLunarName.SharedTypes.Models
{
    public class SolarLunarNameSimple
    {
        public SolarLunarNameSimple(int year, int lunarMonth, int lunarDay)
        {
        Year = year;
        LunarMonth = lunarMonth;
        LunarDay = lunarDay;
        }
        
        private int _year;
        
        public int Year { 
            get {
                return _year ;
                }
            set {

                Helpers.ValidateYear(value);
                _year = value;

            } 
        }
        private int _lunarMonth;
        public int LunarMonth {    
            get {
                return _lunarMonth ;
                }
            set {

                Helpers.ValidateLunarMonth(value);;
                _lunarMonth = value;

            } 
        }
        private int _lunarDay;
        public int LunarDay {    
            get {
                return _lunarDay ;
                }
            set {
                
                Helpers.ValidateLunarDay(value);
                _lunarDay = value;
                
            } 
        }
        

    }



}