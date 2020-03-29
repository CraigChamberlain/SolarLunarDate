using SolarLunarName.SharedTypes.Constants;

namespace SolarLunarName.SharedTypes.Exceptions{
    public class MonthOutOfRangeException : OutOfRangeException
    {
        public MonthOutOfRangeException()
        {
            base._range = Ranges.Month;
        }
    }

}