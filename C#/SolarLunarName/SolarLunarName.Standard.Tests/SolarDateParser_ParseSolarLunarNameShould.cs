using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System;

namespace SolarLunarName.Standard.Tests
{
    public class SolarDateParser_ParseSolarLunarNameShould
    {   
        private SolarDateParser dp;

        public SolarDateParser_ParseSolarLunarNameShould(){

            dp = new SolarDateParser();

        }
        
        private void TestTemplate(string solarLunarDate, int year, int lunarMonth, int lunarDay){
            var parsedObject = dp.ParseSolarLunarName(solarLunarDate);
            
            var result = 
                parsedObject.Year == year &&
                parsedObject.LunarMonth == lunarMonth &&
                parsedObject.LunarDay == lunarDay;

            Assert.True(result, "Should return expected data.");

        }

        [Fact]
        public void ParseSolarLunarNameShould_InputIs201955_Return201955()
        {   
            TestTemplate("2019-5-5", 2019, 5, 5);
        }
    
        [Fact]
        public void ParseSolarLunarNameShould_InputIs175026_Return175026()
        {   
            TestTemplate("1750-2-6", 1750, 2, 6);
        }

        private void ExceptionTemplate(string date){

            Assert.Throws<FormatException>(() => dp.ParseSolarLunarName(date));
            
        }

        [Fact]
        public void ParseSolarLunarNameShould_EmptyString_ThrowFormatException()
        {   
            ExceptionTemplate("");
        }

        [Fact]
        public void ParseSolarLunarNameShould_WrongOrder_ThrowFormatException()
        {   
            ExceptionTemplate("2-6-1750");
        }

        [Fact]
        public void ParseSolarLunarNameShould_InvalidSeparator_ThrowFormatException()
        {   
            ExceptionTemplate("1750/2/6");
        }

        [Fact]
        public void ParseSolarLunarNameShould_ShortYear_ThrowFormatException()
        {   
            ExceptionTemplate("50-2-6");
        }

        [Fact]
        public void ParseSolarLunarNameShould_LongMonth_ThrowFormatException()
        {   
            ExceptionTemplate("1750-100-6");
        }

        [Fact]
        public void ParseSolarLunarNameShould_Incomplete_ThrowFormatException()
        {   
            ExceptionTemplate("1750-10");
        }

    }
    
}