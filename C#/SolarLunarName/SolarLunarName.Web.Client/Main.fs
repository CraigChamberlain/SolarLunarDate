module SolarLunarName.Web.Client.Main

open System
open Elmish
open Bolero
open Bolero.Html
open Bolero.Json
open Bolero.Remoting
open Bolero.Remoting.Client
open Bolero.Templating.Client
open SolarLunarName.SharedTypes.Constants

/// The Elmish application's model.
type Model =
    {
        gregorianDate : DateTime
        solarLunarDate: string option
        error: string option
        solarLunarDateBuilder: SolarLunarDateBuilder
    }

and SolarLunarDateBuilder =
    {
        Year: int
        Month: int
        Day: int
             
    }

let initModel =
    {
        gregorianDate = DateTime.Now
        solarLunarDate = None
        error = None
        solarLunarDateBuilder = { Year = DateTime.Now.Year; Month = 0; Day = 1; } 
    }

/// Remote service definition.
type SolarLunarDateService =
    {
        /// Get the list of all books in the collection.
        getSolarLunarDate: DateTime -> Async<string>

        convertSolarLunarDate: SolarLunarDateBuilder -> Async<Result<DateTime, string>>
    
    }

    interface IRemoteService with
        member this.BasePath = "/solar-lunar-date"

/// The Elmish application's update messages.
type Message =
    | SetDate of DateTime
    | GetSolarLunarDate
    | RecvSolarLunarDate of string
    | RecvGregorianCalendarDate of Result<DateTime, string>
    | Error of exn
    | ClearError
    | Submit
    | SetYear of int
    | SetMonth of int
    | SetDay of int
    
let update remote message (model:Model) =
    match message with
    | SetDate date ->
        { model with solarLunarDate = None; gregorianDate =  date }, Cmd.ofMsg GetSolarLunarDate 
    | GetSolarLunarDate ->
        let cmd = Cmd.ofAsync remote.getSolarLunarDate model.gregorianDate RecvSolarLunarDate Error
        model, cmd    
    | RecvSolarLunarDate solarLunarDate ->
        { model with solarLunarDate = Some solarLunarDate; solarLunarDateBuilder = {Year = Int32.Parse(solarLunarDate.Split('-').[0]); Month =  Int32.Parse(solarLunarDate.Split('-').[1]); Day = Int32.Parse(solarLunarDate.Split('-').[2])}}, Cmd.none
    | Error exn ->
        { model with error = Some exn.Message }, Cmd.none
    | ClearError ->
        { model with error = None }, Cmd.none
    | Submit -> 
        let cmd = Cmd.ofAsync remote.convertSolarLunarDate model.solarLunarDateBuilder RecvGregorianCalendarDate Error
        model, cmd
    | RecvGregorianCalendarDate gregorianCalendarDate ->
        match gregorianCalendarDate with
        | Ok date -> { model with gregorianDate =  date; solarLunarDate = model.solarLunarDateBuilder |> (fun x -> sprintf "%d-%d-%d" x.Year x.Month x.Day) |> Some }, Cmd.ofMsg ClearError
        | Result.Error msg -> { model with error = Some msg }, Cmd.none
    | SetYear y ->
        { model with solarLunarDateBuilder = 
                        { model.solarLunarDateBuilder with Year = y } }, Cmd.none
    | SetMonth m ->
        { model with solarLunarDateBuilder = 
                        { model.solarLunarDateBuilder with Month = m } }, Cmd.none
    | SetDay d ->
        { model with solarLunarDateBuilder = 
                        { model.solarLunarDateBuilder with Day = d } }, Cmd.none

type Main = Template<"wwwroot/main.html">

let strToIntDef (s:string) def =
    match Int32.TryParse s with
    | true, i -> i
    | false, _ -> def


let homePage model dispatch =
    let selectToDate1 = DatePickerComp.datePicker model.gregorianDate (fun d -> d |> SetDate |> dispatch)
    let selectToDate2 = 
                input [ 
                    attr.``type`` "date"
                    //attr.value (model.gregorianDate.ToString("yyyy-MM-dd"))
                    attr.max (sprintf "%d-12-31" Ranges.Year.Max)
                    attr.min (sprintf "%d-01-01" Ranges.Year.Min)
                    bind.change.dateTime model.gregorianDate (fun d -> d |> SetDate |> dispatch)
                ]
        
    let solarLunarDatePicker = form [] [
        input [ attr.``type`` "number"
                attr.max Ranges.Year.Max
                attr.min Ranges.Year.Min
                bind.change.int model.solarLunarDateBuilder.Year (fun y -> y |> SetYear |> dispatch)
              ]
        label [] [text "Year"]

        input [ attr.``type`` "number"
                attr.max Ranges.Month.Max
                attr.min Ranges.Month.Min
                bind.change.int model.solarLunarDateBuilder.Month (fun m -> m |> SetMonth |> dispatch)
        ]
        label [] [text "Month"]

        input [ attr.``type`` "number"  
                attr.max Ranges.Day.Max
                attr.min Ranges.Day.Min
                bind.change.int model.solarLunarDateBuilder.Day (fun d -> d |> SetDay |> dispatch)
                ]
        label [] [text "Day"]

        button [ attr.``type`` "button"
                 on.click (fun d -> dispatch (Submit))
                ] [text "Attempt to Parse Solar Lunar Date"]

    ]
        
    Main
        .Home()
        .GregorianDate1(selectToDate1)
        .GregorianDate2(selectToDate2)
        .GregorianDateString(model.gregorianDate.ToShortDateString())
        .SolarLunarDate(
            cond model.solarLunarDate <| function
            | None -> empty
            | Some string -> Text string
            
        )
        .SolarLunarDatePicker(solarLunarDatePicker)
        .Elt()

    
let view model dispatch =
    Main()
        .Body(
            homePage model dispatch
        )
        .Error(
            cond model.error <| function
            | None -> empty
            | Some err ->
                Main.ErrorNotification()
                    .Text(err)
                    .Hide(fun _ -> dispatch ClearError)
                    .Elt()
        )

        .Elt()

type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        let solarDateService = this.Remote<SolarLunarDateService>()
        let update = update solarDateService
        Program.mkProgram (fun _ -> initModel , Cmd.ofMsg GetSolarLunarDate ) update view
#if DEBUG
     //   |> Program.withHotReload
#endif
