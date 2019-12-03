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
    let gregorianCalendarDate = di.ConvertSolarLunarName 

    override this.Handler =
        {

            getSolarLunarDate = fun dateTime -> async {
                return solarLunarName dateTime |> string
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
