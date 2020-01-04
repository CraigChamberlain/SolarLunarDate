using System.ComponentModel.DataAnnotations;
using SolarLunarName.Standard.Exceptions;

namespace SolarLunarName.Standard.Models
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
                if (value < 1700 || value > 2082)
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
                if (value < 0 || value > 13)
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
                if (value < 1 || value > 31)
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