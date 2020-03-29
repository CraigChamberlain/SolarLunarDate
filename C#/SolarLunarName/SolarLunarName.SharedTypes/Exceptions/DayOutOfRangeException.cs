using SolarLunarName.SharedTypes.Constants;

namespace SolarLunarName.SharedTypes.Exceptions{
    public class DayOutOfRangeException : OutOfRangeException
    {
        public DayOutOfRangeException()
        {
            base._range = Ranges.Day;
        }
    }

}