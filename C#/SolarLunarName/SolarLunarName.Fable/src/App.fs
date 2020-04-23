module App.View

open Elmish
open Fable.React
open Fable.React.Props
open Fulma
open Fulma.Elmish
open Fable.FontAwesome
open System
open App.Services


/// The Elmish application's model.
type Model =
    {
        gregorianDate : DateTime
        solarLunarDate: string option
        error: string option
        solarLunarDateBuilder: SolarLunarDateBuilder
        DatePickerState : DatePicker.Types.State
    }



type Msg =
    | DatePickerChanged of DatePicker.Types.State * (DateTime option)
    | GetSolarLunarDate
    | RecvSolarLunarDate of string
    | RecvGregorianCalendarDate of DateTime
    | Error of exn
    | ClearError
    | Submit
    | SetYear of int
    | SetMonth of int
    | SetDay of int


let init _ = {          
                gregorianDate = DateTime.Now
                solarLunarDate = None
                error = None
                solarLunarDateBuilder = { Year = DateTime.Now.Year; Month = 0; Day = 1; } 
                DatePickerState = 
                  { DatePicker.Types.defaultState with AutoClose = true; ShowDeleteButton = true }
              }, Cmd.ofMsg GetSolarLunarDate


let private update msg model =
    match msg with
    
    | DatePickerChanged (newState, date) ->
        match date with
        | Some d -> // Store the new state and the selected date
                { model with DatePickerState = newState
                             gregorianDate = d }
        | None ->   
                 { model with DatePickerState = newState}                 
        , Cmd.ofMsg GetSolarLunarDate
    | GetSolarLunarDate ->
        let cmd = Cmd.OfPromise.either getSolarLunarName model.gregorianDate RecvSolarLunarDate Error
        model, cmd    
    | RecvSolarLunarDate solarLunarDate ->
        { model with solarLunarDate = Some solarLunarDate; solarLunarDateBuilder = {Year = Int32.Parse(solarLunarDate.Split('-').[0]); Month =  Int32.Parse(solarLunarDate.Split('-').[1]); Day = Int32.Parse(solarLunarDate.Split('-').[2])}}, Cmd.none
    | Error exn ->
        { model with error = Some exn.Message }, Cmd.none
    | ClearError ->
        { model with error = None }, Cmd.none
    | Submit -> 
        let cmd = Cmd.OfPromise.either getConvertedSolarLunarDate model.solarLunarDateBuilder RecvGregorianCalendarDate Error
        model, cmd
    | RecvGregorianCalendarDate date ->
        { model with 
            gregorianDate =  date ; 
            solarLunarDate = model.solarLunarDateBuilder |> (fun x -> sprintf "%d-%d-%d" x.Year x.Month x.Day) |> Some 
            DatePickerState = { model.DatePickerState with ReferenceDate = date }
            }, Cmd.ofMsg ClearError
    | SetYear y ->
        { model with solarLunarDateBuilder = 
                        { model.solarLunarDateBuilder with Year = y } }, Cmd.none
    | SetMonth m ->
        { model with solarLunarDateBuilder = 
                        { model.solarLunarDateBuilder with Month = m } }, Cmd.none
    | SetDay d ->
        { model with solarLunarDateBuilder = 
                        { model.solarLunarDateBuilder with Day = d } }, Cmd.none

// Configuration passed to the components
let pickerConfig: DatePicker.Types.Config<Msg>  = 
        { OnChange = DatePickerChanged
          Local = Date.Local.englishUK
          DatePickerStyle = [ Position PositionOptions.Absolute
                              ZIndex 100
                              MaxWidth "450px" ] }

let root model dispatch =
    DatePicker.View.root pickerConfig model.DatePickerState (Some model.gregorianDate) dispatch


let solarLunarDatePicker model dispatch = 
  form [] [
    Field.div[Field.IsGrouped][
      Field.div []
        [ Label.label [] [str "Year"]
          Control.div [] [ 
            Input.number [ Input.Props 
              [ Max 2081; 
                Min 1700 ; 
                HTMLAttr.Value model.solarLunarDateBuilder.Year;
                OnChange (fun y -> y.Value |> int |> SetYear |> dispatch)
             ] ] 
          ]]
      Field.div []
        [ Label.label [] [str "Month"]
          Control.div [] [ 
            Input.number [ Input.Props 
              [ Max 13; 
                Min 0 ; 
                HTMLAttr.Value model.solarLunarDateBuilder.Month;
                OnChange (fun y -> y.Value |> int |> SetMonth |> dispatch)
             ] ] 
           ]]
      Field.div []     
        [ Label.label [] [str "Day"]
          Control.div [] [ 
            Input.number [ Input.Props 
              [ Max 30; 
                Min 1 ; 
                HTMLAttr.Value model.solarLunarDateBuilder.Day;
                OnChange (fun y -> y.Value |> int |> SetDay |> dispatch)
             ] ] 
           ]]]
    Field.div [ ]
            [ Control.div [ ]
                [ Button.button [ Button.Props 
                  [ HTMLAttr.Type "button"
                    OnClick (fun _ -> dispatch Submit)
                  ] 
                ] [ str "Attempt to Parse Solar Lunar Date" ]]
            ]
     
         
     ]


let private view model dispatch =
    Hero.hero [ Hero.IsFullHeight ]
        [ Hero.body [ ]
            [ Container.container [ ]
                  [ Heading.h1 [ Heading.Modifiers [ 
                                    Modifier.TextColor Color.IsWhiteTer 
                                    Modifier.TextAlignment (Screen.All, TextAlignment.Centered)
                                    ] ] [str "Lunisolar / Gregorian"]
                    Heading.h1 [ Heading.Modifiers [ 
                                    Modifier.TextColor Color.IsWhiteTer 
                                    Modifier.TextAlignment (Screen.All, TextAlignment.Centered)
                                    ] ] [str "Date Converter"]
                    Columns.columns [ Columns.IsVCentered ]
                      [ 
                        Column.column  [ Column.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered)]] [
                           Panel.panel [ Panel.CustomClass "lunisolar" ]
                              [ Panel.heading [ ] [ str "From Lunisolar Date:"]
                                Panel.Block.div [ ]
                                  [ solarLunarDatePicker model dispatch ]]]

                        Column.column  [ Column.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered)]] [
                           Panel.panel [ Panel.CustomClass "gregorian" ]
                              [ Panel.heading [ ] [ str "From Gregorian Date:"]
                                Panel.Block.div [ ] 
                                  [ root model dispatch ]]]

                      ]
                    Columns.columns [Columns.IsCentered ]
                      [ 
                        Column.column  [  Column.Width (Screen.All, Column.Is3) 
                                          Column.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered)]] [  
                          Panel.panel [ Panel.CustomClass "result" ]
                                    [ Panel.heading [ ] [ str "Result"]
                                      Panel.Block.div [ ] 
                                        [
                                          dl [][
                                              dt [] [str "Gregorian Date:"]
                                              dd [] [ model.gregorianDate.ToString("D") |> str ]
                                              dt [] [str "Lunisolar Date:"]
                                              dd [] [ model.solarLunarDate
                                                       |> Option.defaultValue ""
                                                       |>  str
                                                    ]

                                          ]
                                         ] 
                                    ]]]
                      ]]]
                
                

open Elmish.Debug
open Elmish.HMR

Program.mkProgram init update view
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
