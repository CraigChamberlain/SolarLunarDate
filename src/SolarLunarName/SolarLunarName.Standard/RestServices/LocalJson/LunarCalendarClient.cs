using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using System.IO;

namespace SolarLunarName.Standard.RestServices.LocalJson
{

    public class LunarCalendarClient : Json.LunarCalendarClient
    {

        public LunarCalendarClient(string basePath)
        {
            Helpers.TestPath(basePath);
            _basePath = basePath;
        }

        protected string _basePath;

        public override IList<ILunarSolarCalendarMonth> GetYearData(string year)
        {
            string path = Helpers.CombinePath(_basePath, year);
            using (Stream s = File.OpenRead(path)){
                return base.GetYearData(year, s);
            }
        }

        public override ILunarSolarCalendarMonth GetMonthData(int year, int month)
        {
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateLunarMonth(month);
            try{
                string path = Helpers.CombinePath(_basePath, year.ToString(), month.ToString());
                using (Stream s = File.OpenRead(path)){
                    return base.GetMonthData(year, month, s);
                }
            }
            catch (System.IO.DirectoryNotFoundException){

                var monthsInYear = GetYear(year.ToString()).Count;
                throw new SolarLunarName.SharedTypes.Exceptions.MonthDoesNotExistException(year, month, monthsInYear);
            }

        }
        protected override ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month, Stream s) =>          
            base.GetMonthDataDetailed(year, month, s);

        protected override IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year, Stream s) =>
            base.GetYearDataDetailed(year, s);

    }

}
