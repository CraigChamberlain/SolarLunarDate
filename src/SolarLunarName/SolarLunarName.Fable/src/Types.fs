module App.Types

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

type SolarLunarDateBuilder =
    {
        Year: int
        Month: int
        Day: int          
    }  

module Validation =

  type Item = string list option
  type ValidationErrors =
        {
          Year :  Item
          Month : Item
          Day : Item
        } 
        
  let itemHasErrors (item:Item) =
          item <> Some [] &&
          item <> None
    
  let setHasErrors validationErrors =
          itemHasErrors validationErrors.Year ||
          itemHasErrors validationErrors.Month ||
          itemHasErrors validationErrors.Day

  let UncheckedSet = { Year = None; Month = None; Day = None}

  let validateYear year = 
      [ year < 1700 || year > 2081, "Year must be between 1700 and 2081"]
      |> List.filter fst
      |> List.map snd

  let validateMonth month = 
        [ month < 0 || month > 13, "Month must be between 0 and 13"]
        |> List.filter fst
        |> List.map snd

  let validateDay day = 
        [ day < 1 || day > 30, "Day must be between 1 and 30"]
        |> List.filter fst
        |> List.map snd