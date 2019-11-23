## Why is the Moon Involved in the Naming of a Sculpture

The moon, as many will know, is linked to the tides on earth.  It is the orbital relationship of the earth, the moon and also the sun which sum together to create the rising and falling of our oceans.  

My sculptures are taken from the surface of beaches as the tides retreat to reveal ripples in the sand.

I became interested in the physics of the tides and wanted to pull in other significant ideas related to the recording of time.

## About Calendars, the Sun and the Moon

The most widely used Calendar system in the world, the Gregorian calendar, is a solar calendar.  This means that for most people the sun's relationship with the earth dictates time as they measure and record it.  For example the period of the earth's orbit around the sun dicates the 'solar year' more commonly the 'year' and the complete rotation of the earth the 'solar day' or simply 'day'.

However, there are many other calendars and systems of measuring the passage of time.  An astronomer may be more concerned with the rotation of the earth in relation to the stars than the sun, which the earth orbits, and divide their time into ['sidereal days'](https://en.wikipedia.org/wiki/Solar_time).

The Islamic calendar or [Hijra calendar](https://en.wikipedia.org/wiki/Islamic_calendar) is a lunar calendar.  A Hijra year consists of 12 lunar or synodic months each 29 or 30 days long - an intiger approximation for irrational period which can be closer approximated as 29.53 solar days.  Most interestingly, many versions of the Hijra calendar may only be predicted into the future. The exact end of a month and the start of a new are actually revealed by [observation of the new moon](https://en.wikipedia.org/wiki/Islamic_calendar#Astronomical_considerations) by clerics.

<a title="Mostafameraji [CC BY 4.0 (https://creativecommons.org/licenses/by/4.0)], via Wikimedia Commons" href="https://commons.wikimedia.org/wiki/File:%D8%A7%D8%B3%D8%AA%D9%87%D9%84%D8%A7%D9%84_%D9%85%D8%A7%D9%87_%D8%B1%D9%85%D8%B6%D8%A7%D9%86_%D8%AF%D8%B1_%D8%B4%D9%87%D8%B1_%D9%82%D9%85%D8%8C_%D8%B9%DA%A9%D8%A7%D8%B3_%D9%85%D8%B5%D8%B7%D9%81%DB%8C_%D9%85%D8%B9%D8%B1%D8%A7%D8%AC%DB%8C%D8%8C_%D8%A8%D9%84%D9%86%D8%AF%DB%8C_%D9%87%D8%A7%DB%8C_%D8%A8%D9%88%D8%B3%D8%AA%D8%A7%D9%86_%D8%B9%D9%84%D9%88%DB%8C_%D9%82%D9%85_12.jpg" target="_blank"><img width="512" alt="استهلال ماه رمضان در شهر قم، عکاس مصطفی معراجی، بلندی های بوستان علوی قم 12" src="https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/%D8%A7%D8%B3%D8%AA%D9%87%D9%84%D8%A7%D9%84_%D9%85%D8%A7%D9%87_%D8%B1%D9%85%D8%B6%D8%A7%D9%86_%D8%AF%D8%B1_%D8%B4%D9%87%D8%B1_%D9%82%D9%85%D8%8C_%D8%B9%DA%A9%D8%A7%D8%B3_%D9%85%D8%B5%D8%B7%D9%81%DB%8C_%D9%85%D8%B9%D8%B1%D8%A7%D8%AC%DB%8C%D8%8C_%D8%A8%D9%84%D9%86%D8%AF%DB%8C_%D9%87%D8%A7%DB%8C_%D8%A8%D9%88%D8%B3%D8%AA%D8%A7%D9%86_%D8%B9%D9%84%D9%88%DB%8C_%D9%82%D9%85_12.jpg/512px-%D8%A7%D8%B3%D8%AA%D9%87%D9%84%D8%A7%D9%84_%D9%85%D8%A7%D9%87_%D8%B1%D9%85%D8%B6%D8%A7%D9%86_%D8%AF%D8%B1_%D8%B4%D9%87%D8%B1_%D9%82%D9%85%D8%8C_%D8%B9%DA%A9%D8%A7%D8%B3_%D9%85%D8%B5%D8%B7%D9%81%DB%8C_%D9%85%D8%B9%D8%B1%D8%A7%D8%AC%DB%8C%D8%8C_%D8%A8%D9%84%D9%86%D8%AF%DB%8C_%D9%87%D8%A7%DB%8C_%D8%A8%D9%88%D8%B3%D8%AA%D8%A7%D9%86_%D8%B9%D9%84%D9%88%DB%8C_%D9%82%D9%85_12.jpg"></a>

Although, the two calendars above are charactorised as Solar and Lunar respectively, both remain influenced by the sun and the moon.  For example in the Gregorian calendar the months are between 29 and 31 days, very close to the synodic month of ~29.53 days.  [Indeed the word "month" shares a common root with the word "moon".](https://www.etymonline.com/word/Month) Similarly, although the year and the month of the Hijra are defined by the moon, the day is dictated by the rising and setting of the sun.

There is a third class of calendar, the [Lunisolar calendars](https://en.wikipedia.org/wiki/Lunisolar_calendar) of which there are a great many examples throughout the world.

## Why a New Calendar?

Now time is measured in ticks from unixtime 0.  Atomic clock, interest inrecovering complexity and nature from past.

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

[My proposed calendar](/my-calendar)
[technology](/technology)