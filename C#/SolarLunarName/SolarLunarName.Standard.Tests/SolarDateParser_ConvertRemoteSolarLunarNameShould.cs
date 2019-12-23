using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;

namespace SolarLunarName.Standard.Tests
{
    public class SolarDateParser_ConvertRemoteSolarLunarName
    {   
        private SolarDateParser di;

        public SolarDateParser_ConvertRemoteSolarLunarName(){

            di = new SolarDateParser();

        }
        
        private void TestTemplate(int year, int month, int day, int lunarMonth, int lunarDay){
            var UtcDateTime = new DateTime(year, month, day);
            var remoteName = di.ConvertRemoteSolarLunarName(year, lunarMonth, lunarDay);
            
            var result = remoteName == UtcDateTime;

            Assert.True(result, "Should return expected data.");

        }

        [Fact]
        public void ConvertRemoteSolarLunarNameShould_InputIs201954_Return08052019()
        {   
            TestTemplate(2019, 5, 8, 5, 5);
        }
    
        [Fact]
        public void ConvertRemoteSolarLunarNameShould_InputIs175026_Return11021750()
        {   
            TestTemplate(1750, 2, 11, 2, 6);
        }
    
    }
    
}