namespace SolarLunarName.Web.Server

open System
open System.IO
open Microsoft.AspNetCore.Hosting
open Bolero
open Bolero.Remoting
open Bolero.Remoting.Server
open SolarLunarName.Web
open SolarLunarName.Standard.RestServices.LocalJson

type SolarLunarDateService(ctx: IRemoteContext, env: IWebHostEnvironment) =
    inherit RemoteHandler<Client.Main.SolarLunarDateService>()
    
    let client = MoonDataClient(@"/home/craig/Documents/src/moon-data/api/new-moon-data");
    let di = SolarLunarName.Standard.ApplicationServices.DateInstantiator(client)
    let solarLunarName dateTime = di.GetSolarLunarName(dateTime)
    
    let calClient = LunarCalendarClient(@"/home/craig/Documents/src/moon-data/api/lunar-solar-calendar")
    let dp = SolarLunarName.Standard.ApplicationServices.SolarDateParser(calClient)
    let gregorianCalendarDate = dp.ConvertSolarLunarName 

    override this.Handler =
        {

            getSolarLunarDate = fun dateTime -> async {
                return solarLunarName dateTime |> (fun x -> sprintf "%d-%d-%d" x.Year x.LunarMonth x.LunarDay)                 
                }
            
            convertSolarLunarDate = 

                
                    fun solarLunarDate -> async{
                        try
                        let date =  gregorianCalendarDate(solarLunarDate.Year, solarLunarDate.Month, solarLunarDate.Day)
                        return Ok(date)
                        with 
                        | :? System.InvalidOperationException ->  
                            return Error "Try a smaller month. You may have tried to parse for a day ot month that does not exist in this calendar." 
            }
            
        }
