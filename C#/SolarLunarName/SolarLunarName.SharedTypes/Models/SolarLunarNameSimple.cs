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
        
        private int _year;
        public int Year { 
            get {
                return _year ;
                }
            set {
                if (! Ranges.Year.InRange(value))
                {
                    throw new YearOutOfRangeException();
                }
                else
                {
                    _year = value;
                }
            } 
        }
        private int _lunarMonth;
        public int LunarMonth {    
            get {
                return _lunarMonth ;
                }
            set {
                if (! Ranges.Month.InRange(value))
                {
                    throw new MonthOutOfRangeException();
                }
                else
                {
                    _lunarMonth = value;
                }
            } 
        }
        private int _lunarDay;
        public int LunarDay {    
            get {
                return _lunarDay ;
                }
            set {
                if (! Ranges.Day.InRange(value))
                {
                    throw new DayOutOfRangeException();
                }
                else
                {
                    _lunarDay = value;
                }
            } 
        }

    }



}