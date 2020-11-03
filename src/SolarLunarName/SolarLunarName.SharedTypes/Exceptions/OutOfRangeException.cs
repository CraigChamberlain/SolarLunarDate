using System;
using SolarLunarName.SharedTypes.Constants;

namespace SolarLunarName.SharedTypes.Exceptions{
    public abstract class OutOfRangeException: ArgumentOutOfRangeException{

        
        protected Range _range;
        public override string Message
        {
            get
            {
                return $"{ _range.Label } must be between {_range.Min} and {_range.Max }";
            }
        }

        public override string ParamName
        {
            get
            {
                return _range.Label ;
            }
        }
    }

}