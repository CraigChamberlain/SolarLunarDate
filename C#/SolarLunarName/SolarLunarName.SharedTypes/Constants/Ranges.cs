using System;

namespace SolarLunarName.SharedTypes.Constants{
    public class Range{
        public Range(string label, int min, int max)
        {
            Label = label;
            Min = min;
            Max = max;
        }

        public string Label { get; }
        public int Min { get; }
        public int Max { get; }

        public bool InRange(int value){          
            
            return (value >= Min && value <= Max);

        }


    }
    public static class Ranges{
        public static Range Month = new Range("Month", 0, 13);
        public static Range Day = new Range("Day", 1, 31);
        static public Range Year = new Range("Year", 1700, 2081);
    }

}