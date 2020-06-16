module App.Types

open Fable.Validation.Core

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

 let validateYear (year:int)= 
      fast <| fun t ->
          t.Test "year" year
                    |> t.Gte 1700 "should greater then {min}"
                    |> t.Lte 2081 "shoudld less then {max}"
                    |> t.End 