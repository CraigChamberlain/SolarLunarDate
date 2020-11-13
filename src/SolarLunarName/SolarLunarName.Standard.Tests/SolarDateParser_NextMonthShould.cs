using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.SharedTypes.Exceptions;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.Collections.Generic;
using System;

namespace SolarLunarName.Standard.Tests
{   public class MockClient: ISolarLunarCalendarClient
    {
        public IList<ILunarSolarCalendarMonth> GetYearData(ValidYear year){
            
            return new List<ILunarSolarCalendarMonth>{
                new LunarSolarCalendarMonth(19, new DateTime(1700,1,1)),
                new LunarSolarCalendarMonth(29,new DateTime(1700,01,20)),
                new LunarSolarCalendarMonth(30,new DateTime(1700,02,18)),
                new LunarSolarCalendarMonth(30,new DateTime(1700,03,20)),
                new LunarSolarCalendarMonth(29,new DateTime(1700,04,19)),
                new LunarSolarCalendarMonth(30,new DateTime(1700,05,18)),
                new LunarSolarCalendarMonth(29,new DateTime(1700,06,17)),
                new LunarSolarCalendarMonth(29,new DateTime(1700,07,16)),
                new LunarSolarCalendarMonth(30,new DateTime(1700,08,14)),
                new LunarSolarCalendarMonth(29,new DateTime(1700,09,13)),
                new LunarSolarCalendarMonth(29,new DateTime(1700,10,12)),
                new LunarSolarCalendarMonth(30,new DateTime(1700,11,10)),
                new LunarSolarCalendarMonth(22,new DateTime(1700,12,10))
            };
        }
        public ILunarSolarCalendarMonth GetMonthData(ValidYear year, ValidLunarMonth month)=> throw new NotImplementedException();
        public IList<DateTime> GetYear(ValidYear year)=> throw new NotImplementedException();
        public ILunarSolarCalendarMonth GetMonthData(int year, int month)=> throw new NotImplementedException();
        public IList<DateTime> GetYear(string year)=> throw new NotImplementedException();
        public IList<ILunarSolarCalendarMonth> GetYearData(string year)=> GetYearData((ValidYear)year);
    }
    public class SolarDateParser_NextMonthShould
    {   
        private SolarDateParser dp;
        private ISolarLunarCalendarClient _client;
        

        public SolarDateParser_NextMonthShould(){
            _client = new MockClient();
            dp = new SolarDateParser(_client);

        }

        [Fact]
        private void NextMonthShould_ResolveNextMonth_WhenDaysOverFlowMonth(){
            var initialDate = new SolarLunarNameSimple(1700, 0, 20); 
            var nextDate = new SolarLunarNameSimple(1700, 1, 1);
            TestTemplate(initialDate, nextDate);
        }

        [Fact]
        private void NextMonthShould_ResolveNextMonth_WhenMonthsOverFlowYear(){
            var initialDate = new SolarLunarNameSimple(1700, 13, 7); 
            var nextDate = new SolarLunarNameSimple(1701, 0, 7);
            TestTemplate(initialDate, nextDate);
        }

        [Fact]
        private void NextMonthShould_ResolveNextMonth_WhenDaysOverFlowYear(){
            var initialDate = new SolarLunarNameSimple(1700, 12, 23);
            var nextDate = new SolarLunarNameSimple(1701, 0, 1);
            TestTemplate(initialDate, nextDate);
        }

        [Fact]
        private void NextMonthShould_ResolveNextMonth_WhenDaysAndMonthsNotOverFlowMonthOrYear(){
            var initialDate = new SolarLunarNameSimple(1700, 0, 1);
            var nextDate = new SolarLunarNameSimple(1700, 0, 1);
            TestTemplate(initialDate, nextDate);
        }

        [Fact]
        private void NextMonthShould_ResolveNextMonth_WhenDaysAndMonthsOverFlowYearAndMonth(){
            var initialDate = new SolarLunarNameSimple(1700, 13, 9);
            var nextDate = new SolarLunarNameSimple(1701, 0, 9);
            TestTemplate(initialDate, nextDate);
        }
        
        private void TestTemplate(SolarLunarNameSimple initialDate, SolarLunarNameSimple nextDate){
            var nextSolarLunarDate = dp.NextMonth(initialDate);
            
            var result = 
                nextSolarLunarDate.Year == nextDate.Year &&
                nextSolarLunarDate.LunarMonth == nextDate.LunarMonth &&
                nextSolarLunarDate.LunarDay == nextDate.LunarDay;

            Assert.True(result, "Should return expected data.");

        }

        //TODO This is not really a test of NextMonth which does not throw exceptions of its own
        // This may be covered by tests on its dependency the calendar client
        private void ExceptionTemplate(int year, int lunarMonth, int lunarDay){
            var solarLunarDate = new SolarLunarNameSimple(year, lunarMonth, lunarDay);
            Assert.Throws<YearOutOfRangeException>(() => dp.NextMonth(solarLunarDate));
        }


        [Fact]
        public void NextMonthShould_YearTooHigh_ThrowException()
        {   
            ExceptionTemplate(2081,13,3);
        }

    }
    
}