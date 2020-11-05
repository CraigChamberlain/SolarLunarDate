using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.Net.Http;
using System;
using System.IO;

namespace SolarLunarName.Standard.RestServices.RemoteJson
{

    public class LunarCalendarClient : Json.LunarCalendarClient
    {

        public LunarCalendarClient(HttpClient client, string baseUrl = "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar/")
        {
            _baseUrl = baseUrl;
            _client = client;
        }

        protected HttpClient _client;
        protected string _baseUrl;

        public override IList<ILunarSolarCalendarMonth> GetYearData(ValidYear year)
        {
            Uri uri = Helpers.CombinePath(_baseUrl, year);
            using (Stream s = _client.GetStreamAsync(uri).Result){
               return base.GetYearData(year, s);
            };
        }

        public override ILunarSolarCalendarMonth GetMonthData(ValidYear year, ValidLunarMonth month)
        {
            try
            {
                Uri uri = Helpers.CombinePath(_baseUrl, year, month);
                using (Stream s = _client.GetStreamAsync(uri).Result){
                return base.GetMonthData(year, month, s);
                };
            }
            catch (HttpRequestException)
            {

                var monthsInYear = GetYear(year).Count;
                throw new SolarLunarName.SharedTypes.Exceptions.MonthDoesNotExistException(year, month, monthsInYear);
            }

        }
        protected override ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(ValidYear year, ValidLunarMonth month, Stream s) =>
            base.GetMonthDataDetailed(year, month, s);

        protected override IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(ValidYear year, Stream s) =>
            base.GetYearDataDetailed(year, s);

    }

}
