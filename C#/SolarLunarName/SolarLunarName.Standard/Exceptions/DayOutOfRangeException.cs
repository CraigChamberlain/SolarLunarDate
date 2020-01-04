using System;

namespace SolarLunarName.Standard.Exceptions{
    public class DayOutOfRangeException: ArgumentOutOfRangeException{
        public override string Message
        {
            get
            {
                return "Day must be between 1 and 31";
            }
        }

        public override string ParamName
        {
            get
            {
                return "Day";
            }
        }
    }

}