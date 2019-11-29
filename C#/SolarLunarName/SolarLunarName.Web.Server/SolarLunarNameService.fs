namespace SolarLunarName.Web.Server

open System.IO
open Microsoft.AspNetCore.Hosting
open Bolero
open Bolero.Remoting
open Bolero.Remoting.Server
open SolarLunarName.Web

type SolarLunarDateService(ctx: IRemoteContext, env: IWebHostEnvironment) =
    inherit RemoteHandler<Client.Main.SolarLunarDateService>()
    
    let di = SolarLunarName.Standard.ApplicationServices.DateInterpreter()
    let solarLunarName dateTime = di.GetSolarLunarName(dateTime)

    override this.Handler =
        {

            getSolarLunarDate = fun dateTime -> async {
                return solarLunarName dateTime |> string
            }


        }
