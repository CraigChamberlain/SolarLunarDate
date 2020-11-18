using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;
using SolarLunarName.SharedTypes.Exceptions;
using SolarLunarName.SharedTypes.Primitives;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.Standard.RestServices.LocalJson;

namespace SolarLunarName.Standard.Tests.JsonClient
{
    abstract public class GetMonthDataExceptions
    {   
        protected ISolarLunarCalendarClient _client;

        [Fact]
        public void Client_Should_Raise_MonthDoesNotExistException(){
          
           Assert.Throws<MonthDoesNotExistException>(() => _client.GetMonthData((ValidYear)1700, (ValidLunarMonth)13)); 
        }

        [Fact]
        public void Client_Should_Not_Raise_Exception(){
           try{ 
               _client.GetMonthData((ValidYear)1700, (ValidLunarMonth)12);
           }
           catch (Exception e) {
               Assert.True(false, e.Message);
           }

        }

    }
    
}