using SolarLunarName.SharedTypes.Constants;

namespace SolarLunarName.SharedTypes.Exceptions{
    public class DateDoesNotExistException : System.Exception
    {
        public override string Message => "Date does not Exist.";
    }

}