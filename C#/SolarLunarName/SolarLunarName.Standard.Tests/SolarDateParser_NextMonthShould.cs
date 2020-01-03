using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System;
using SolarLunarName.Standard.Models;

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
        public void NextMonthShould_InputIs201955_Return201955()
        {   
            TestTemplate(2019, 5, 50, 2019, 6, 20);
        }
    
    }
    
}