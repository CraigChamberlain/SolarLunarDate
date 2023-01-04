---
layout: q-n-a
title: Technology
redirect_from: technology.html
questions: 
    - q: What technology is used in the software component of this project?
      a: |
        Basic algorithms may be ported in several technologies but will initially be written in F# and C# for .NET Core & consumed by a PowerShell CLI, and a Elmish [Fable](https://fable.io/) app.  Source code is currently hosted on this [github repo.](https://github.com/CraigChamberlain/SolarLunarDate)
    - q: 'External APIs in use:'
      a: |
        -  [ADMIRALTY API](https://admiraltyapi.portal.azure-api.net/) 
           
           Has tides by location.

        -  [The United States Naval Observatory (USNO)](https://aa.usno.navy.mil/data/docs/api.php#phase)
        
           Appears to be off-line for maintenance but have permission to serve data processed from this source.
           [Example response](/SolarLunarDate/USNO/ExampleYear.json){:target="_blank"}

---
