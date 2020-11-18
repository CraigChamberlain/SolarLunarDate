using System;
using Xunit;
using SolarLunarName.SharedTypes.Exceptions;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.SharedTypes.Tests
{
    public class ValidLunarMonth_CastingValidationExceptions
    {
        [Theory]
        [InlineData(14)]
        [InlineData(Int32.MaxValue)]
        public void MonthToBig(int month){
            Assert.Throws<MonthOutOfRangeException>(() => (ValidLunarMonth)month);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(Int32.MinValue)]
        public void YearToSmall(int month){
            Assert.Throws<MonthOutOfRangeException>(() => (ValidLunarMonth)month);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(13)]
        public void YearOK(int month){
            var x = (ValidLunarMonth)month;
        } 


    }
}
