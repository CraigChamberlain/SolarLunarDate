namespace SolarLunarName.Standard.Tests.Paths{

    public static class Common{
        internal static string CalendarApi(string relativePath) => relativePath + "lunar-solar-calendar";
        internal static string DetailedcalendarApi(string relativePath) => relativePath + "lunar-solar-calendar-detailed";
        internal static string NewMoonApi(string relativePath) => relativePath + "new-moon-data"; 
    }
    public static class Local{
        internal const string relativePath = @"../../../../../paket-files/github.com/CraigChamberlain/moon-data/api/"; 
        internal static string CalendarApi = Common.CalendarApi(relativePath);
        internal static string DetailedcalendarApi = Common.DetailedcalendarApi(relativePath);
        internal static string NewMoonApi = Common.NewMoonApi(relativePath);
    }
    public static class Remote{
        internal const string relativePath = "https://craigchamberlain.github.io/moon-data/api/";
        internal static string CalendarApi => Common.CalendarApi(relativePath);
        internal static string DetailedcalendarApi => Common.DetailedcalendarApi(relativePath);
        internal static string NewMoonApi => Common.NewMoonApi(relativePath);
    }

}