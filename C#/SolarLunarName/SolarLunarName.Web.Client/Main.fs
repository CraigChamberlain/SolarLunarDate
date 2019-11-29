module SolarLunarName.Web.Client.Main

open System
open Elmish
open Bolero
open Bolero.Html
open Bolero.Json
open Bolero.Remoting
open Bolero.Remoting.Client
open Bolero.Templating.Client


/// The Elmish application's model.
type Model =
    {
        gregorianDate : DateTime
        solarLunarDate: string option
        error: string option
    }

let initModel =
    {
        gregorianDate = DateTime.Now
        solarLunarDate = None
        error = None
    }

/// Remote service definition.
type SolarLunarDateService =
    {
        /// Get the list of all books in the collection.
        getSolarLunarDate: DateTime -> Async<string>
    
    }

    interface IRemoteService with
        member this.BasePath = "/solar-lunar-date"

/// The Elmish application's update messages.
type Message =
    | SetDate of string
    | GetSolarLunarDate of DateTime
    | RecvSolarLunarDate of string
    | Error of exn
    | ClearError
    
let update remote message (model:Model) =
    match message with
    | SetDate d ->
        let date = DateTime.Parse d
        { model with solarLunarDate = None; gregorianDate =  date }, Cmd.ofMsg (GetSolarLunarDate date)
    | GetSolarLunarDate d ->
        let cmd = Cmd.ofAsync remote.getSolarLunarDate d RecvSolarLunarDate Error
        model, cmd    
    | RecvSolarLunarDate solarLunarDate ->
        { model with solarLunarDate = Some solarLunarDate }, Cmd.none
    | Error exn ->
        { model with error = Some exn.Message }, Cmd.none
    | ClearError ->
        { model with error = None }, Cmd.none


type Main = Template<"wwwroot/main.html">

let homePage model dispatch =
    Main
        .Home()
        .GregorianDate(string model.gregorianDate, (fun d -> dispatch (SetDate d) ))
        .SolarLunarDate(
            cond model.solarLunarDate <| function
            | None -> empty
            | Some string -> Text string
            
        )
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
        Program.mkProgram (fun _ -> initModel , Cmd.none ) update view
#if DEBUG
     //   |> Program.withHotReload
#endif
