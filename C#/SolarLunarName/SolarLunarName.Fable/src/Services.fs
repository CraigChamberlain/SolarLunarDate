module App.Services

open Thoth.Fetch
open App.Types

let getYear (year : int)  = 
  promise {
    let url = sprintf "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar-detailed/%d/" year
    return! Fetch.get<_, Month array>(url)
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
  
let convertSolarLunarName (date:SolarLunarDateBuilder) (year: Month array) =
    
    let month = 
        year
        |> Array.tryFind (fun month -> month.Month = date.Month )
    match month with 
    | Some month -> month.FirstDay.AddDays(date.Day - 1 |> float ) |> Ok
    | None -> Error "Month not found"

    
let getSolarLunarName (date:System.DateTime) =
  date.Year
  |> getYear 
  |> Promise.map (solarLunarName date)

let getConvertedSolarLunarDate (date:SolarLunarDateBuilder) =
  date.Year
  |> getYear 
  |> Promise.map (convertSolarLunarName date)