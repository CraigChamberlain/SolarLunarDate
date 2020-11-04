using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;
using SolarLunarName.SharedTypes.Models;

namespace SolarLunarName.Standard.Tests
{
    public class LunarCalendarClient_ConstructorShould : LocalJsonClient_ConstructorShould
    {   
        override public void Constructor(string input){
            new Standard.RestServices.LocalJson.LunarCalendarClient(input);
        }
    }
    
}