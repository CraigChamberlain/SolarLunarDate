---
layout: q-n-a
title: My Calendar
redirect_from: my-calendar.html
questions: 
    - q: 'This Calendar will use Coordinated Universal Time (UTC):'
      a: |
        The moon has the same phase apparent to the earth irrespective of time zone.  Initially, my calendar will not count hours.  A local component and a subdivision of the day may be introduced at a later date.  For example tides may bisect a day but depend very largely on locality as do, sunrises and sunsets.
    - q: 'The Measurement of Years:'
      a: |
        The earth completes a circuit of the sun roughly, every 365.25 days.  Any given point in this cycle could be called the start/end of a year although there are four natural points to choose from, namely the [solstices](https://en.wikipedia.org/wiki/Solstice) and [equinoxes](https://en.wikipedia.org/wiki/Equinox).  For example in the Gregorian calendar, the new year is related but not identical to the winter solstice which is usually the 21st or 22nd of December, the shortest day of the year as experienced in the Northern Hemisphere (N.B this same event would be observed as the summer solstice in the Southern Hemisphere).

        This calender could have taken the dates of one of these astronomical events as the start of its year.  However, I have decided to count my years in the Common Era and begin the year on the 1st of January in the Gregorian Calendar.  This will make the calendar simpler to implement and simpler to understand, as a map onto the Gregorian Calendar.  I may make a "strict mode" at a later date, which would be largely in phase but not sync with the Gregorian Calendar.
    - q: 'The Measurement of Months:'
      a: |
        ![Figure 1.](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=400&height=200&select=d1rjgmgOwa)

        12 complete lunar months have 354.36 days, 10.88 days less than the solar year.  Depending on the age of the moon at the start of a solar year it may have 11 or 12 whole months and one or two partial months.  Typically in a lunisolar calendar, this means that to preserve complete a lunar month, year ends must be approximated to the end of a lunar month.  If a lunisolar year typically has 12 lunar months then extra months must be added on particular years to make up for lost days, in the way leap days are added to years in the Gregorian Calendar.

        However this forces the year to vary considerably in length and requires complex patterns to decide in which year to add a month.  This calendar will favour the complete solar year and split the months that fall over the start and end of a year.

        This is not completely unprecedented and is somewhat related to the concept of uncounted time.  [Some Coast Salish peoples used a calendar of this kind. For instance, the Chehalis began their count of lunar months from the arrival of spawning chinook salmon (in Gregorian calendar October), and counted 10 months, leaving an uncounted period until the next chinook salmon run.](https://en.wikipedia.org/wiki/Lunisolar_calendar#With_uncounted_time)

        Therefore, months will begin on the day of the new moon or the start of a new year.  Months will end on the day before the new moon or the end of the year.

        There are 4 cases of how lunar months may intersect a given solar year. In all cases there are 13 or 14 resulting months.  As lunar month lengths vary somewhat the figures given for age of the moon in each case are based on a simplified model and may be out by a day or so in some years.
        
        When the age of the moon approximates to 0 days on the start of the year:

        ![Figure 2.2](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=400&height=200&select=bUzavqqsE)

        When the age of the moon approximates to between 1 and 10 days inclusive on the start of the year:

        ![Figure 2.1](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=427.2&height=214.08&select=ag1mmNc0S)
        
        When the age of the moon approximates to between 11 and 19 days on the start of the year, or the last day of the last lunar month is also the last day of the year:

        ![Figure 2.3](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=427.2&height=214.08&select=aKSCDJb1I)

        When the age of the moon approximates to between 20 days and ~28 days (or two days before the end of the month) on the start of the year:

        ![Figure 2.3](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=427.2&height=214.08&select=a2YzVlfzRu)

        

    - q: 'Identifying the Date of the New Moon:'
      a: | 
        The new moon will be identified by API lookup or calculation.  It will not depend on observation. 
    - q: 'The Naming of Months:'
      a: |
        Months will be named 0-13.  I chose 0 as the first month as it will only be a complete month in exceptional circumstances.  It would be fun to name the final month X for the same reasons.  However, I will stick with integers as I also like the reference to [the indexing of sequences which begins at 0 in computing and mathematics](https://en.wikipedia.org/wiki/Zero-based_numbering).
    - q: 'Length of Month:'
      a: |
        The Lunar month is not a whole number of days.  Therefore the calendar months will have variable lengths.

        ![Figure 3.](https://vectr.com/craigchamberlain11/d9InyNA1qX.svg?width=400&height=400&select=d9InyNA1qXpage0)

        Each month will have have 29-30 days.
    - q: 'Displaying Dates:'
      a: |
        A date in this calendar will typically have a Year, a Month, a Day and a UTC Gregorian DateTime.

        I would like to have variations that include the phase of the moon 

        ```{SolarYear}-{FullMoonsOfYTD}-{DaysOfCurrentMoon} 
        e.g 2018-10-12```


        It would be good to have a version that made more of the Phase of the Moon, this would make it more universal, and limit the problems associated with crushing time zone.

        ```{SolarYear}-{FullMoonsOfYTD}-{Phase of Moon in 1/8ths of Moon}  
        e.g 2018-10-1/2```

        Finally I would really like to include some notion of geographic location, particularly tide which is experienced heterogeneously across the surface of the earth.

        This may be displayed as follows but would perhaps include co-ordinates in the object.

        ```{SolarYear}-{FullMoonsOfYTD}-{DaysOfCurrentMoon}-{Tide}  
        e.g 2018-10-12-1```
    - q: 'The calendar in practice:'
      a: |
        - [A basic visualisation in a familiar calendar layout](https://craigchamberlain.github.io/SolarLunarCalendar/)
        - [Convert to and from the calendar online](/SolarLunarDate/tool)
        - [Explore an API](https://craigchamberlain.github.io/moon-data/)
        - [Convert dates and query the calendar with a PowerShell module](https://www.powershellgallery.com/packages/SolarLunarName/)

---
