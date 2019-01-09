using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;


namespace SolarLunarName.Standard.RestServices.Usno
{
    public class UsnoApi
    {

        const string BaseUrl = "https://api.usno.navy.mil/";

        public T Execute<T>(RestRequest request) where T : new()
        {

            var client = new RestClient(BaseUrl);

            client.RemoteCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var usnoException = new ApplicationException(message, response.ErrorException);
                throw usnoException;
            }
            return response.Data;

        }

        public MoonPhaseResponse GetMoonPhaseCalendar(string year)
        {

            var request = new RestRequest("/moon/phase", Method.GET);
            request.AddQueryParameter("year", year);
            request.AddQueryParameter("Id", "CChamb");
            // execute the request
            //IRestResponse response = client.Execute(request);
            //var content = response.Content; // raw content as string

            return Execute<MoonPhaseResponse>(request);

        }


        public class MoonPhaseResponse
        {
            public string Error { get; set; }
            public string ApiVersion { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
            public int NumPhases { get; set; }
            public string DateChanged { get; set; }
            public List<PhaseDataResponse> PhaseData { get; set; }

        }

        public class PhaseDataResponse
        {
            public string Phase { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }

        }
    }
}
