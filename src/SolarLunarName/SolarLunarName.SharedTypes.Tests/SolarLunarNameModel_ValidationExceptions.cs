using System;
using Xunit;
using SolarLunarName.SharedTypes.Exceptions;
using SolarLunarName.SharedTypes.Models;

namespace SolarLunarName.SharedTypes.Tests
{
    public class SolarLunarNameModel_ValidationExceptions
    {
        [Fact]
        public void YearToBig(){
            Assert.Throws<YearOutOfRangeException>(() => new SolarLunarNameModel(DateTime.Parse("1700-01-01T00:00:00"), 2082,9,1));
        }
        [Fact]
        public void YearToSmall(){
            Assert.Throws<YearOutOfRangeException>(() => new SolarLunarNameModel(DateTime.Parse("1700-01-01T00:00:00"), 1699,9,1));
        }

        [Fact]
        public void MonthToBig(){
            Assert.Throws<MonthOutOfRangeException>(() => new SolarLunarNameModel(DateTime.Parse("1700-01-01T00:00:00"), 2081,14,1));
        }
        [Fact]
        public void MonthToSmall(){
            Assert.Throws<MonthOutOfRangeException>(() => new SolarLunarNameModel(DateTime.Parse("1700-01-01T00:00:00"), 2081,-1,1));
        }

        [Fact]
        public void DayToBig(){
            Assert.Throws<DayOutOfRangeException>(() => new SolarLunarNameModel(DateTime.Parse("1700-01-01T00:00:00"), 2081,1,32));
        }
        [Fact]
        public void DayToSmall(){
            Assert.Throws<DayOutOfRangeException>(() => new SolarLunarNameModel(DateTime.Parse("1700-01-01T00:00:00"), 2081,1,0));
        }
        [Fact]
        public void DateTimeToBig(){
            Assert.Throws<YearOutOfRangeException>(() => new SolarLunarNameModel(DateTime.Parse("2082-01-01T00:00:00"), 2081,1,1));
        }
        [Fact]
        public void DateTimeSmall(){
            Assert.Throws<YearOutOfRangeException>(() => new SolarLunarNameModel(DateTime.Parse("1699-01-01T00:00:00"), 2081,1,1));
        }



    }
}
