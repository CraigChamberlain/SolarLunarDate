![Figure 1.](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=640&height=640&select=d9InyNA1qXpage0)

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

