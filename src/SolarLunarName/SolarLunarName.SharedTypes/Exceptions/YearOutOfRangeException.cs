using SolarLunarName.SharedTypes.Constants;

namespace SolarLunarName.SharedTypes.Exceptions{
    public class YearOutOfRangeException : OutOfRangeException
    {
        public YearOutOfRangeException()
        {
            base._range = Ranges.Year;
        }
    }

}