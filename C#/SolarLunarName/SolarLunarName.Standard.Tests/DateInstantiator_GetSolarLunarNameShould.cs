using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;

namespace SolarLunarName.Standard.Tests
{
    public class DateInstantiator_GetSolarLunarNameShould
    {   
        private DateInstantiator di;

        public DateInstantiator_GetSolarLunarNameShould(){

            di = new DateInstantiator();

        }

        private void TestTemplate(int year, int month, int day, int lunarMonth, int lunarDay){
            var UtcDateTime = new DateTime(year, month, day);
            var remoteName = di.GetRemoteSolarLunarName(UtcDateTime);
            
            var result = 
                remoteName.LunarMonth == lunarMonth 
                && remoteName.LunarDay == lunarDay
                && remoteName.Year == year
                && remoteName.SolarDateTime == UtcDateTime;

            Assert.True(result, "Should return expected data.");

        }

        [Fact]
        public void GetSolarLunarNameShould_InputIs08052019_Return201954()
        {   
            TestTemplate(2019, 5, 8, 5, 5);
        }
    
        [Fact]
        public void GetSolarLunarNameShould_InputIs11021750_Return175026()
        {   
            TestTemplate(1750, 2, 11, 2, 6);
        }
    }
    
}