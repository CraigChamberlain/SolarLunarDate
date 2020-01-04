using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System;
using SolarLunarName.Standard.Models;
using SolarLunarName.Standard.Exceptions;

namespace SolarLunarName.Standard.Tests
{
    public class SolarDateParser_NextMonthShould
    {   
        private SolarDateParser dp;

        public SolarDateParser_NextMonthShould(){

            dp = new SolarDateParser();

        }
        
        private void TestTemplate(int year, int lunarMonth, int lunarDay, int nextYear, int nextLunarMonth, int nextLunarDay){
            var solarLunarDate = new SolarLunarNameSimple(year, lunarMonth, lunarDay);
            var nextSolarLunarDate = dp.NextMonth(solarLunarDate);
            
            var result = 
                nextSolarLunarDate.Year == nextYear &&
                nextSolarLunarDate.LunarMonth == nextLunarMonth &&
                nextSolarLunarDate.LunarDay == nextLunarDay;

            Assert.True(result, "Should return expected data.");

        }

        [Fact]
        public void NextMonthShould_InputIs20190531_Return20190601()
        {   
            TestTemplate(2019, 5, 31, 2019, 6, 1);
        }
    
        [Fact]
        public void NextMonthShould_InputIs17001307_Return17010107()
        {   
            TestTemplate(1700, 13, 7, 1701, 0, 7);
        }
    
        [Fact]
        public void NextMonthShould_InputIs17001309_Return17010009()
        {   
            TestTemplate(1700, 13, 9, 1701, 0, 9);
            //TestTemplate(1700, 13, 9, 1701, 1, 1); if applied recursively
        }

        [Fact]
        public void NextMonthShould_InputIs17010009_Return17010101()
        {   
            TestTemplate(1701, 0, 9, 1701, 1, 1);
        }

         private void ExceptionTemplate(int year, int lunarMonth, int lunarDay){
            var solarLunarDate = new SolarLunarNameSimple(year, lunarMonth, lunarDay);
            Assert.Throws<YearOutOfRangeException>(() => dp.NextMonth(solarLunarDate));
        }

        [Fact]
        public void NextMonthShould_YearTooHigh_ThrowException()
        {   
            ExceptionTemplate(2082,9,1);
        }

    }
    
}