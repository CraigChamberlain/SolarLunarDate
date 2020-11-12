using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.Standard.RestServices.RemoteJson;

namespace SolarLunarName.Standard.Tests.RemoteJson
{
    public class MoonDataClient_ConstructorShould: JsonClient_ConstructorShould
    {   
        override public void Constructor(string input){
            new MoonDataClient(_client, input);
        }
    }
    
}