using SolarLunarName.Standard.RestServices.Admiralty;
using System;
using SolarLunarName.Standard.ApplicationServices;
using SQLite;
using SolarLunarName.Standard.Models;
using System.Collections.Generic;

namespace SolarLunarName.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //DateTime date = DateTime.Parse("2015/1/1");
                //var phase = new MoonPhase(date);
                //var phase2 = SunCalc.GetMoonIllumination(date);
                
                var httpClient = new System.Net.Http.HttpClient( );
                string ApiKey = System.Configuration.ConfigurationManager.AppSettings["AdmiraltyApiKey"];
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);

                var StationsClient = new StationsClient(httpClient);
                var station = string.Empty;
                //var results = StationsClient.GetStationsAsync(station).GetAwaiter().GetResult();


                //foreach (var feature in results.Features) {
                //    Console.WriteLine(feature.Properties);
                //}

                //var Usno = new UsnoApi();
                //var result1 = Usno.GetMoonPhaseCalendar("2018");
                //var dateTime = DateTime.Now;
                //var ting = new GetSolarLunarName(dateTime);
                //Console.WriteLine(ting.ToString());

                //var dateTime1 = DateTime.Now.AddYears(-14);
                //var ting1 = new GetSolarLunarName(dateTime1);
                //Console.WriteLine(ting1.ToString());

                var db = new DataAccess();
                var years = System.Linq.Enumerable.Range(1900, 3000);
                foreach (int year in years)
                {
                    db.PopulateYear(year.ToString());
                }
                var dateTime2 = DateTime.Now.AddDays(3);
                var ting2 = new GetSolarLunarName(dateTime2);
                Console.WriteLine(ting2.ToString());


                Console.ReadKey();
            }

            
        }
    }
}