module App.View

open Elmish
open Fable.React
open Fable.React.Props
open Fulma
open Fulma.Elmish
open Fable.FontAwesome
open System
open App.Services
open App.Types


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
                [ Columns.columns [ Columns.CustomClass "has-text-centered" ]
                    [ Column.column [ Column.Width(Screen.All, Column.IsOneThird)
                                      Column.Offset(Screen.All, Column.IsOneThird) ]
                        [ Image.image [ Image.Is128x128
                                        Image.Props [ Style [ Margin "auto"] ] ]
                            [ img [ Src "assets/fulma_logo.svg" ] ]

                          Field.div [] 
                            [ Heading.h3 [ Heading.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Left)] ] [str "Gregorian Date:"]
                              root model dispatch
                            ]
                          
                          Field.div [Field.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Left)]]
                            [  
                               Heading.h3 [] [str "Lunisolar Date:"]
                               Text.p [] 
                                [  model.solarLunarDate
                                   |> Option.defaultValue ""
                                   |>  str 
                                ]
                            ]
                          Field.div []  
                            [  
                               Heading.h3 [ Heading.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Left)]] [str "Convert Lunisolar Date to Gregorian Calendar:"]
                               solarLunarDatePicker model dispatch
                            ]

                        ] ] ] ] ]
                                    

open Elmish.Debug
open Elmish.HMR

Program.mkProgram init update view
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
