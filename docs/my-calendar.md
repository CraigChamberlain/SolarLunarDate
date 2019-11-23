## Why is the Moon Involved in the Naming of a Sculpture

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

