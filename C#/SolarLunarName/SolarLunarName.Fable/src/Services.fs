module App.Services

open Thoth.Fetch

type Phase = 
    { Phase: int
      Days: int
      DateTime: System.DateTime
      FirstDay: System.DateTime
      LastDay: System.DateTime }

type Month = 
  { Phases: Phase array
    Month: int
    Days: int
    FirstDay: System.DateTime
  }

let getYear year = promise {
    let! year = Fetch.get<Month array>(sprintf "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar-detailed/%d/" year)

    return year
        
}

let normalise (date:System.DateTime) =
  System.DateTime(date.Year, date.Month, date.Day)

let solarLunarName (gregorianDate:System.DateTime) (year: Month array) =
    
    let normalDate = normalise gregorianDate
    let dateIsLessOrEqual date = date <= normalDate
    let month = 
        year
        |> Array.rev  
        |> Array.find (fun month -> dateIsLessOrEqual month.FirstDay)

    let day = gregorianDate.DayOfYear - month.FirstDay.DayOfYear + 1
    
    sprintf "%d-%d-%d" gregorianDate.Year month.Month day
  

  
let getSolarLunarName (date:System.DateTime) =
  date.Year
  |> getYear 
  |> Promise.map (solarLunarName date)
