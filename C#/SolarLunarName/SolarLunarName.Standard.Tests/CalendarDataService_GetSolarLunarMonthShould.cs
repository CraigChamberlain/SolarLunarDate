using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;

namespace SolarLunarName.Standard.Tests
{
    public class CalendarDataService_GetSolarLunarMonthShould
    {   
        private readonly DetailedCalendarDataService _calendarDataService;

        public CalendarDataService_GetSolarLunarMonthShould(){
            var client = new Standard.RestServices.LocalJson.LunarCalendarClientDetailed(@"../../../../../../../moon-data/api/lunar-solar-calendar-detailed");
            _calendarDataService = new DetailedCalendarDataService(client);
        }

        [Fact]
        public void GetSolarLunarMonthShould_InputIs1700_ReturnCorrectMonthData()
        {
            var month = _calendarDataService.GetSolarLunarMonth(1700,0);

            var monthLiteral = new Models.LunarSolarCalendarMonth(19, DateTime.Parse("1700-01-01T00:00:00"));

            var result =  month.FirstDay == monthLiteral.FirstDay && month.Days == monthLiteral.Days;

            Assert.True(result, "Returns correct year month.");
        }
    }
    
}