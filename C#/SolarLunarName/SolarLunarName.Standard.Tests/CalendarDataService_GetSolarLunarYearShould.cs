using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;

namespace SolarLunarName.Standard.Tests
{
    public class CalendarDataService_GetSolarLunarYearShould
    {   
        private readonly CalendarDataService _calendarDataService;

        public CalendarDataService_GetSolarLunarYearShould(){
            var client = new Standard.RestServices.LocalJson.LunarCalendarClient(@"../../../../../../../moon-data/api/lunar-solar-calendar");
            _calendarDataService = new CalendarDataService(client);
        }

        [Fact]
        public void GetSolarLunarYearShould_InputIs1700_ReturnCorrectYearData()
        {
            var year = _calendarDataService.GetSolarLunarYear(1700);

            var yearLiteral = new List <Models.LunarSolarCalendarMonth>{
                new Models.LunarSolarCalendarMonth(19, DateTime.Parse("1700-01-01T00:00:00")),
                new Models.LunarSolarCalendarMonth(29, DateTime.Parse("1700-01-20T00:00:00")),
                new Models.LunarSolarCalendarMonth(30, DateTime.Parse("1700-02-18T00:00:00")),
                new Models.LunarSolarCalendarMonth(30, DateTime.Parse("1700-03-20T00:00:00")),
                new Models.LunarSolarCalendarMonth(29, DateTime.Parse("1700-04-19T00:00:00")),
                new Models.LunarSolarCalendarMonth(30, DateTime.Parse("1700-05-18T00:00:00")),
                new Models.LunarSolarCalendarMonth(29, DateTime.Parse("1700-06-17T00:00:00")),
                new Models.LunarSolarCalendarMonth(29, DateTime.Parse("1700-07-16T00:00:00")),
                new Models.LunarSolarCalendarMonth(30, DateTime.Parse("1700-08-14T00:00:00")),
                new Models.LunarSolarCalendarMonth(29, DateTime.Parse("1700-09-13T00:00:00")),
                new Models.LunarSolarCalendarMonth(29, DateTime.Parse("1700-10-12T00:00:00")),
                new Models.LunarSolarCalendarMonth(30, DateTime.Parse("1700-11-10T00:00:00")),
                new Models.LunarSolarCalendarMonth(22, DateTime.Parse("1700-12-10T00:00:00"))
            };

            var result = yearLiteral
                            .Zip(year, (m1, m2) => m1.FirstDay == m2.FirstDay && m1.Days == m2.Days )
                            .All(x => x);

            Assert.True(result, "Returns correct year data.");
        }
    }
    
}