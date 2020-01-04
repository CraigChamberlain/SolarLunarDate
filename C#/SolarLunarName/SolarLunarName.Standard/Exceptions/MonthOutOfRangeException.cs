using System;

namespace SolarLunarName.Standard.Exceptions{
    public class MonthOutOfRangeException: ArgumentOutOfRangeException{
        public override string Message
        {
            get
            {
                return "Month must be between 1 and 13";
            }
        }

        public override string ParamName
        {
            get
            {
                return "Month";
            }
        }
    }

}