using System;
using SolarLunarName.SharedTypes.Interfaces;

namespace SolarLunarName.SharedTypes.Models
{
    public class LunarSolarCalendarMonth : ILunarSolarCalendarMonth
    {
        public LunarSolarCalendarMonth(int days, DateTime date){
            Days = days;
            FirstDay = date;
        }
        
        public int Days { get; set; }
        public DateTime FirstDay { get; set;}
    }
}