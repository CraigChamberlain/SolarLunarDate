# SolarLunarDate
_Utility to help name Beach Cast sculpture on a Solar/Lunar Calendar_

[![Build Status](https://travis-ci.com/CraigChamberlain/SolarLunarDate.svg?branch=master)](https://travis-ci.com/CraigChamberlain/SolarLunarDate)

## Calendar Justification and Specification
I have a written up the justification and specification of the SolarLunarCalendar [here.](https://craigchamberlain.github.io/SolarLunarDate/)

## Example Calendar
There is also a simple diagramatic representation of each Calendar year from 1700 - 2082 [here.](https://craigchamberlain.github.io/SolarLunarCalendar)

## About this Utility
The utility is currently largely contained in a .Net Standard Class Library - 
[SolarLunarName.Standard](https://github.com/CraigChamberlain/SolarLunarDate/tree/master/C%23/SolarLunarName/SolarLunarName.Standard).  I have attempted to make a type that closely follows the dotnet [DateTime struct Api](https://docs.microsoft.com/en-us/dotnet/api/system.datetime). This class library has limited integration tests at present which I plan to improve and also introduce unit tests.  

The solution also has a PowerShell module (nearly finished). I will add these both as a nuget package once I have solved a few more problems.

There is also an Bolero/Blazor webpage in the early stages of development and I began a Xamarin Application initially but is not seeing active development at the momement.

## Solar Lunar Data api
Finally I have public api for moon data and my calendar implementation [here.](https://github.com/CraigChamberlain/moon-data)
