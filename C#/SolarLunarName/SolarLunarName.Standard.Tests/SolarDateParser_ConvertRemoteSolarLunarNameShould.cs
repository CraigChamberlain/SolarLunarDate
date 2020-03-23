using System;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using SolarLunarName.Standard.RestServices.LocalJson;

namespace SolarLunarName.Standard.Tests
{
    public class SolarDateParser_ConvertSolarLunarName
    {   
        private SolarDateParser di;

        public SolarDateParser_ConvertSolarLunarName(){

            di = new SolarDateParser( new LunarCalendarClient(@"../../../../../../../moon-data/api/lunar-solar-calendar") );

        }
        
        private void TestTemplate(int year, int month, int day, int lunarMonth, int lunarDay){
            var UtcDateTime = new DateTime(year, month, day);
            var remoteName = di.ConvertSolarLunarName(year, lunarMonth, lunarDay);
            
            var result = remoteName == UtcDateTime;

            Assert.True(result, "Should return expected data.");

        }

        [Fact]
        public void ConvertSolarLunarNameShould_InputIs201954_Return08052019()
        {   
            TestTemplate(2019, 5, 8, 5, 5);
        }
    
        [Fact]
        public void ConvertSolarLunarNameShould_InputIs175026_Return11021750()
        {   
            TestTemplate(1750, 2, 11, 2, 6);
        }
    
    }
    
}