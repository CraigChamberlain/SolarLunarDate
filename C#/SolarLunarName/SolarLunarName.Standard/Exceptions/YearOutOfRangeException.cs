using System;

namespace SolarLunarName.Standard.Exceptions{
    public class YearOutOfRangeException: ArgumentOutOfRangeException{
        public override string Message
        {
            get
            {
                return "Year must be between 1700 and 2082";
            }
        }

        public override string ParamName
        {
            get
            {
                return "Year";
            }
        }
    }

}