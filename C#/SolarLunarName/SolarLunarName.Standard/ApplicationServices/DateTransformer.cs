using SolarLunarName.SharedTypes.Models;

namespace SolarLunarName.Standard.ApplicationServices
{
    public class DateTransformer
    {
        public DateTransformer(DateInstantiator dateInstantiator){
            di = dateInstantiator;

        }
        private DateInstantiator di;

         public SolarLunarNameModel AddDays(SolarLunarNameModel solarLunarName, double value){
            
            return di.GetSolarLunarName(solarLunarName.SolarDateTime.AddDays(value));

        }

        public SolarLunarNameModel AddMonths(SolarLunarNameModel solarLunarName, int value){

            return di.GetSolarLunarName(solarLunarName.SolarDateTime.AddMonths(value));
            
        }

        public SolarLunarNameModel AddYears(SolarLunarNameModel solarLunarName, int value){

            return di.GetSolarLunarName(solarLunarName.SolarDateTime.AddYears(value));
            
        }

    }
    
}

