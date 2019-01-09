using System;
using System.Collections.Generic;
using System.Text;

namespace SolarLunarName.Standard.Models
{
    public class Location
    {
        Country Country { get; set; }
        string Id { get; set; }
        string Name { get; set; }


    }
    public enum Country
    {
        England,
        Wales,
        Scotland,
        NorthernIreland
    }
}
