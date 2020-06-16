---
layout: q-n-a
title: Technology

questions: 
    - q: What technology is used in the software component of this project?
      a: |
        Basic algorithms may be ported in several technologies but will initially be written in F# and C# for .NET Core & consumed by a Powershell CLI, and a Fable app.  Sourcecode is currently hosted on this [github repo](https://github.com/CraigChamberlain/SolarLunarDate)
    - q: 'External APIs in use:'
      a: |
        -  [ADMIRALTY API](https://admiraltyapi.portal.azure-api.net/) 
           
           Has tides by location.

        -  [The United States Naval Observatory (USNO)](https://aa.usno.navy.mil/data/docs/api.php#phase)
        
           Appears to be off-line for maintainence but have permission to serve data processed from this source.
           [Example response](/USNO/ExampleYear.json){:target="_blank"}

---
