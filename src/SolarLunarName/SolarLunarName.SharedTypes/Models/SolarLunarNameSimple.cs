using SolarLunarName.SharedTypes.Exceptions;
using SolarLunarName.SharedTypes.Constants;

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
        
        protected void ValidationHelper<Exp>(int value, Range range) where Exp : System.Exception, new()  {
                if (! range.InRange(value))
                {
                    throw new Exp();
                }
        }

        private int _year;
        
        public int Year { 
            get {
                return _year ;
                }
            set {

                ValidationHelper<YearOutOfRangeException>(value, Ranges.Year);
                _year = value;

            } 
        }
        private int _lunarMonth;
        public int LunarMonth {    
            get {
                return _lunarMonth ;
                }
            set {

                ValidationHelper<MonthOutOfRangeException>(value, Ranges.Month);
                _lunarMonth = value;

            } 
        }
        private int _lunarDay;
        public int LunarDay {    
            get {
                return _lunarDay ;
                }
            set {
                
                ValidationHelper<DayOutOfRangeException>(value, Ranges.Day);
                _lunarDay = value;
                
            } 
        }
        

    }



}