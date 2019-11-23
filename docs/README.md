# SolarLunarDate
Utility to help name Beach Cast sculpture on a Solar/Lunar Calendar

## Date format may ultimately be one of the following
- {SolarYear}-{FullmoonsOfYTD}-{Phase of Moon in 1/8ths of Moon}  
  e.g 2018-10-1/2
  Only input would be a datetime object
- {SolarYear}-{FullmoonsOfYTD}-{DaysOfCurrentMoon} 
  e.g 2018-10-12
  Only input would be a datetime object
- {SolarYear}-{FullmoonsOfYTD}-{DaysOfCurrentMoon}-{Tide}  
  e.g 2018-10-12-1
  Would require a some location parameters in addition to datetime.  It may be possible to estimate the tide but it would be most likely looked up via a 3rd party API. 
  
## APIs 
[ADMIRALTY API](https://admiraltyapi.portal.azure-api.net/)
Has tides by location.

[The United States Naval Observatory (USNO)](https://aa.usno.navy.mil/data/docs/api.php#phase)
Appears to be off-line for maintainence.  Will request permission to serve a cached version.
[Example response](/USNO/ExampleYear.json){:target="_blank"}

## Technology
Basic algorithm may be ported in several technologies but will initially be written in F# and C# for .NET Core & consumed by a Powershell CLI, a Bolero/Blazor webpage and Xamarin Applications.
