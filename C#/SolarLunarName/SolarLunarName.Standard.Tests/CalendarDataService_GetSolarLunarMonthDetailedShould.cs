using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;
using SolarLunarName.SharedTypes.Models;

namespace SolarLunarName.Standard.Tests
{
    public class CalendarDataService_GetSolarLunarMonthDetailedShould
    {   
        private readonly DetailedCalendarDataService _calendarDataService;

        public CalendarDataService_GetSolarLunarMonthDetailedShould(){
            var client = new Standard.RestServices.LocalJson.LunarCalendarClientDetailed(@"../../../../../../../moon-data/api/lunar-solar-calendar-detailed");
            _calendarDataService = new DetailedCalendarDataService(client);
        }

        [Fact]
        public void GetSolarLunarMonthDetailedShould_InputIs1700_ReturnCorrectMonthData()
        {
            var month = _calendarDataService.GetDetailedSolarLunarMonth(1700,0);

            var phasesLiteral = new List <MoonPhaseEntity>{
                new MoonPhaseEntity(DateTime.Parse("1700-01-01T00:00:00"), DateTime.Parse("1700-01-01T00:00:00"), DateTime.Parse("1700-01-04T00:00:00"), Moon.MoonPhase.Partial, 4),
                new MoonPhaseEntity(DateTime.Parse("1700-01-05T10:30:00"), DateTime.Parse("1700-01-05T00:00:00"), DateTime.Parse("1700-01-11T00:00:00"), Moon.MoonPhase.FullMoon, 7),
            };
            
            var monthLiteral = new LunarSolarCalendarMonthDetailed(19, 0, DateTime.Parse("1700-01-01T00:00:00"), phasesLiteral);

            Assert.True(month.FirstDay == monthLiteral.FirstDay, "Returns correct First Day.");
            Assert.True(month.Days == monthLiteral.Days, "Returns correct number of days.");
            Assert.True(month.Month == monthLiteral.Month, "Returns correct month.");
            Assert.True(
                    month.Phases
                        .Take(2)
                        .Zip(phasesLiteral)
                        .All(x => 
                            x.First.Date == x.Second.Date &&
                            x.First.FirstDay == x.Second.FirstDay &&
                            x.First.LastDay == x.Second.LastDay &&
                            x.First.Phase == x.Second.Phase &&
                            x.First.Days == x.Second.Days                             
                            ), 
                            "Returns correct Phases."
                        
            );
            
        }
    }
    
}