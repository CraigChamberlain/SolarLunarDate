## This Calendar will use Coordinated Universal Time (UTC)

The moon has the same phase apparent to the earth irispective of time zone.  Initially, my calendar will not count hours.  A local component and a subdivision of the day may be introduced at a later date.  Particularly when if another element of locality, tides is added.

## The Measurement of Years

The earth completes a circuit of the sun roughly, every 365.25 days.  Any given point in this cycle could be called the start/end of a year although there are four natural points to choose from, namely the [solstices](https://en.wikipedia.org/wiki/Solstice) and [equinoxes](https://en.wikipedia.org/wiki/Equinox).  For example in the Gregorian calendar, the new year is related but not identical to the winter solsice which is usually the 21st or 22nd of December, the shortest day of the year as experienced in the Northern Hemisphere (N.B this same event would be observed as the summer solstice in the Southern Hemisphere).

This calander could have taken the dates of one of these astronmical events as the start of its year.  However, I have decided to count my years in the Common Era and begin the year on the 1st of Janurary in the Gregorian Calendar.  This will make the calendar simpler to implement and simpler to understand, as a map onto the Gegorian Calendar.  I may make a "strict mode" at a later date, which would be largely in phase but not sync with the Gregorian Calendar.

## The Measurement of Months

![Figure 1.](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=400&height=200&select=d1rjgmgOwa)

There are between 12 and 13 lunar months in a solar year.  Typically in a lunisolar calendar, this means that to preserve complete year and month cycle, extra months must be added on particular years, in the way leep days are added to years in the Gregorian Calendar.

However this forces the year to vary considerably in length and requires complex patterns to decide which year to add a month.  This calendar will favour year and split the month that falls over the end of one year and the start of the following.

This is not completely unpresidented and is somewhat related to the concept of uncounted time.  [Some Coast Salish peoples used a calendar of this kind. For instance, the Chehalis began their count of lunar months from the arrival of spawning chinook salmon (in Gregorian calendar October), and counted 10 months, leaving an uncounted period until the next chinook salmon run.[3]](https://en.wikipedia.org/wiki/Lunisolar_calendar#With_uncounted_time)

Therefore, months will begin on the day of the new moon or the start of a new year.  Months will end on the day before the new moon or the end of the year.

![Figure 2.](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=400&height=200&select=bUzavqqsE)

## Identifying the Date of the New Moon

The new moon will be identified by api lookup or calculation.  It will not depend on observation. 

## The Naming of Months

Months will be named 0-13.  I chose 0 as the first month as it will only be a complete month in exceptional circumstances.  It would be fun to name the final month X for the same reasons.  However, I will stick with integers as I also like the reference to [the indexing of sequences which begins at 0 in computing and mathematics](https://en.wikipedia.org/wiki/Zero-based_numbering).

## Lenghth of Month
The Synodal month is not a whole number of days.  Therefore the calendar months will have varialble lenghts.

![Figure 3.](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=400&height=400&select=d9InyNA1qXpage0)

Each month will have have 29-30 days.

## Displaying Dates

A date in this calendar will typically have a Year, a Month, a Day and a UTC Gregian DateTime.

I would like to have variations that include the phase of the moon 

    {SolarYear}-{FullmoonsOfYTD}-{DaysOfCurrentMoon} 
    e.g 2018-10-12


It would be good to have a verison that made more of the Phase of the Moon, this would make it more universal, and limit the problems assosiated with crushing timezone.

    {SolarYear}-{FullmoonsOfYTD}-{Phase of Moon in 1/8ths of Moon}  
    e.g 2018-10-1/2
  
Finally I would really like to include some notion of geographic location, particualy tide which is experience hetrogeniously accross on the surphase of the earth.

This may be displayed as follows but would perhaps include co-ordinates in the object.

    {SolarYear}-{FullmoonsOfYTD}-{DaysOfCurrentMoon}-{Tide}  
    e.g 2018-10-12-1