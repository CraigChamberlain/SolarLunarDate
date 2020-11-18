using System;
using Xunit;
using SolarLunarName.SharedTypes.Exceptions;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.SharedTypes.Tests
{
    public class ValidYear_CastingValidationExceptions
    {
        [Theory]
        [InlineData(2082)]
        [InlineData(Int32.MaxValue)]
        public void YearToBig(int year){
            Assert.Throws<YearOutOfRangeException>(() => (ValidYear)year);
        }
        [Theory]
        [InlineData(1699)]
        [InlineData(-1699)]
        [InlineData(0)]
        [InlineData(Int32.MinValue)]
        public void YearToSmall(int year){
            Assert.Throws<YearOutOfRangeException>(() => (ValidYear)year);
        }
        [Theory]
        [InlineData(1700)]
        [InlineData(2081)]
        [InlineData(1850)]
        public void YearOK(int year){
            var x =  (ValidYear)year;
        } 


    }
}
