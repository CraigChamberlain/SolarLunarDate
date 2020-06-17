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
open App.Types.Validation


/// The Elmish application's model.
type Model =
    {
        GregorianDate : DateTime
        SolarLunarDate: string option
        Error: string option
        SolarLunarDateBuilder: SolarLunarDateBuilder
        DatePickerState : DatePicker.Types.State
        ValidationErrors : ValidationErrors
        ModalState: bool
        AwaitingRequest: bool
    }

type Msg =
    | DatePickerChanged of DatePicker.Types.State * (DateTime option)
    | GetSolarLunarDate
    | RecvSolarLunarDate of string
    | RecvGregorianCalendarDate of Result<DateTime,string>
    | ErrorMessage of exn
    | ClearError
    | Submit
    | SetYear of int
    | SetMonth of int
    | SetDay of int
    | ValidateYear
    | ValidateMonth
    | ValidateDay
    | ToggleModal


let init _ = {
                GregorianDate = DateTime.Now
                SolarLunarDate = None
                Error = None
                SolarLunarDateBuilder = { Year = DateTime.Now.Year; Month = 0; Day = 1; }
                DatePickerState =
                  { DatePicker.Types.defaultState with AutoClose = true; ShowDeleteButton = true }
                ValidationErrors = Validation.UncheckedSet
                ModalState = false
                AwaitingRequest = false
              }, Cmd.ofMsg GetSolarLunarDate

let private update msg model =
    match msg with

    | DatePickerChanged (newState, date) ->
        match date with
        | Some d -> // Store the new state and the selected date
                { model with DatePickerState = newState
                             GregorianDate = d }
        | None ->
                 { model with DatePickerState = newState}
        , Cmd.ofMsg GetSolarLunarDate
    | GetSolarLunarDate ->
        let cmd = Cmd.OfPromise.either getSolarLunarName model.GregorianDate RecvSolarLunarDate ErrorMessage
        { model with AwaitingRequest = true }, cmd
    | RecvSolarLunarDate solarLunarDate ->
        { model with 
            AwaitingRequest = false
            SolarLunarDate = Some solarLunarDate; 
            SolarLunarDateBuilder = { 
                Year = Int32.Parse(solarLunarDate.Split('-').[0]); 
                Month =  Int32.Parse(solarLunarDate.Split('-').[1]); 
                Day = Int32.Parse(solarLunarDate.Split('-').[2])
            }
        }, Cmd.ofMsg ClearError
    | ErrorMessage exn ->
        { model with 
            Error = Some exn.Message 
            AwaitingRequest = false
        }, Cmd.ofMsg ToggleModal
    | ClearError ->
        { model with Error = None }, Cmd.none
    | Submit ->
        let cmd = Cmd.OfPromise.either getConvertedSolarLunarDate model.SolarLunarDateBuilder RecvGregorianCalendarDate ErrorMessage
        { model with AwaitingRequest = true }, cmd
    | RecvGregorianCalendarDate date ->
        match date with
        | Ok date ->
          { model with
              AwaitingRequest = false
              GregorianDate =  date ;
              SolarLunarDate = model.SolarLunarDateBuilder |> (fun x -> sprintf "%d-%d-%d" x.Year x.Month x.Day) |> Some
              DatePickerState = { model.DatePickerState with ReferenceDate = date }
              }, Cmd.ofMsg ClearError
        | Error message -> 
           { model with
                AwaitingRequest = false
                Error = Some message }, Cmd.none
 
    | SetYear y ->
        { model with SolarLunarDateBuilder =
                        { model.SolarLunarDateBuilder with Year = y } }, Cmd.ofMsg ValidateYear
    | SetMonth m ->
        { model with SolarLunarDateBuilder =
                        { model.SolarLunarDateBuilder with Month = m } }, Cmd.ofMsg ValidateMonth
    | SetDay d ->
        { model with SolarLunarDateBuilder =
                        { model.SolarLunarDateBuilder with Day = d } }, Cmd.ofMsg ValidateDay
    | ValidateYear ->        
        let yearErrors = validateYear model.SolarLunarDateBuilder.Year
        let errors = { model.ValidationErrors with Year = Some yearErrors }
        { model with ValidationErrors = errors  }, Cmd.none
    | ValidateMonth ->        
        let monthErrors = validateMonth model.SolarLunarDateBuilder.Month
        let errors = { model.ValidationErrors with Month = Some monthErrors }
        { model with ValidationErrors = errors  }, Cmd.none
    | ValidateDay ->
        let dayErrors = validateDay model.SolarLunarDateBuilder.Day
        let errors = { model.ValidationErrors with Day = Some dayErrors }
        { model with ValidationErrors = errors  }, Cmd.none
    | ToggleModal ->
        { model with ModalState = not model.ModalState }, Cmd.none

// Configuration passed to the components
let pickerConfig: DatePicker.Types.Config<Msg>  =
        { OnChange = DatePickerChanged
          Local = Date.Local.englishUK
          DatePickerStyle = [ Position PositionOptions.Absolute
                              ZIndex 100
                              MaxWidth "450px" ] 
             
         }

let root model dispatch =
    DatePicker.View.root pickerConfig model.DatePickerState (Some model.GregorianDate) dispatch

let solarLunarDatePickerItem dispatch title (value:int) errors msg = 
  Field.div []
        [ Label.label [] [str title]
          Control.div [] [
            Input.number [ 
              Input.Props
                [ HTMLAttr.Value value;
                  OnChange (fun y -> y.Value |> int |> msg |> dispatch)
              ] 
              match errors with
                  | Some [] -> Input.Color IsSuccess
                  | Some _ -> Input.Color IsDanger
                  | None -> () 
               ]
          ]
          match errors with
              | Some [] ->
                  Help.help  [ Help.Color IsSuccess ] [ sprintf "This %s is valid" title |> str ]
              | Some errorList ->
                  let errorListHtml = ul [] (errorList |> List.map (fun e -> li [ ] [ str e ]) )
                  Help.help  [ Help.Color IsDanger ] [errorListHtml]
              | _ -> ()  
          ]

let solarLunarDatePicker model dispatch =
  form [] [
    Field.div[Field.IsGrouped][
      let solarLunarDatePickerItem' = solarLunarDatePickerItem dispatch
      solarLunarDatePickerItem'  "Year" model.SolarLunarDateBuilder.Year model.ValidationErrors.Year SetYear
      solarLunarDatePickerItem'  "Month" model.SolarLunarDateBuilder.Month model.ValidationErrors.Month SetMonth
      solarLunarDatePickerItem'  "Day" model.SolarLunarDateBuilder.Day model.ValidationErrors.Day SetDay
    ]
    Field.div [ ]
            [ Control.div [ ]
                [ Button.button [ Button.Props
                  [ HTMLAttr.Type "button"
                    OnClick (fun _ -> dispatch Submit)
                    Disabled <| Validation.setHasErrors model.ValidationErrors
                  ]
                ] [ str "Attempt to Parse Solar Lunar Date" ]]
            ]


     ]

let loading = 
  div [Class "loading" ] [ 
    div [Class "lds-ring" ] [ 
      div [] [] 
      div [] []
      div [] []
      div [] []
      ]
    ]

let result model =  
   Panel.panel [ Panel.CustomClass "result" ]
              [ Panel.heading [ ] [ str "Result"]
                Panel.Block.div [ ]
                  [

                    if model.AwaitingRequest then loading
                    match model.Error with 
                    | None -> 
                        dl [][
                            dt [] [str "Gregorian Date:"]
                            dd [] [ model.GregorianDate.ToString("D") |> str ]
                            dt [] [str "Lunisolar Date:"]
                            dd [] [ model.SolarLunarDate
                                     |> Option.defaultValue ""
                                     |>  str
                                  ]

                        ]
                    | Some error -> str error 
                    
                   ]
              ]



let basicModal  model dispatch =
    Modal.modal [ Modal.IsActive model.ModalState ]
        [ Modal.background [ Props [ OnClick (fun _ -> dispatch ToggleModal) ] ] [ ]
          Modal.content [ ]
            [ Box.box' [ ] [result model] ]
          Modal.close [ Modal.Close.Size IsLarge
                        Modal.Close.OnClick (fun _ -> dispatch ToggleModal) ] [ ] ]



let private view model dispatch =
    Hero.hero [ Hero.IsFullHeight ]
        [ Hero.body [ ]
            [ Container.container [ ]
                  [ Heading.h1 [ Heading.Modifiers [
                                    Modifier.TextSize (Screen.Mobile, TextSize.Is4)
                                    Modifier.TextColor Color.IsWhiteTer
                                    Modifier.TextAlignment (Screen.All, TextAlignment.Centered)
                                    ] ] [str "Lunisolar / Gregorian"]
                    Heading.h1 [ Heading.Modifiers [
                                    Modifier.TextSize (Screen.Mobile, TextSize.Is2)
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
                        result model
                        div [ ]
                             [ basicModal model dispatch ]
                        ]]
                      ]]]



open Elmish.Debug
open Elmish.HMR

Program.mkProgram init update view
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
