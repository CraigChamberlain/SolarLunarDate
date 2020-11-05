using System;
using System.Management.Automation;
using SolarLunarName.Standard.ApplicationServices;
using SolarLunarName.Standard.RestServices.RemoteJson;
using System.Net.Http;

namespace SolarLunarName.PoSH
{
    [Cmdlet(
        VerbsData.ConvertFrom, 
        "SolarLunarName",
        DefaultParameterSetName = "Object"
    )]
    public class ConvertFromSolarLunarName : PSCmdlet
    {   

        [Parameter(
            Position = 0, 
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "Object"
        )]
        [ValidateYear()]
        public int Year { get; set; }

        [Parameter(
            Position = 1, 
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "Object"
        )]
        [ValidateMonth()]
        public int Month  { get; set; }

        [Parameter(
            Position = 2, 
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "Object"
        )]
        [ValidateDay()]
        public int Day  { get; set; }

        [Parameter(
            Position = 0, 
            Mandatory = true, 
            ValueFromPipeline = true,
            ParameterSetName = "String"
        )]
        public string SolarLunarDate  { get; set; }

        private SolarDateParser sdp;
        private DateTime gregorianCalendarDate;
        private HttpClient _httpClient;

        protected override void BeginProcessing(){
            _httpClient = new HttpClient();
            sdp = new SolarDateParser(new LunarCalendarClient(_httpClient));

        }

        protected override void ProcessRecord()
        {   
            if(ParameterSetName == "Object"){
                gregorianCalendarDate = 
                    sdp.ConvertSolarLunarName(Year, Month, Day);
            }
            else{
                gregorianCalendarDate = 
                    sdp.ConvertRemoteSolarLunarName(SolarLunarDate);
            }
            this.WriteObject(gregorianCalendarDate);
            base.EndProcessing();
        }
    }
}
    

