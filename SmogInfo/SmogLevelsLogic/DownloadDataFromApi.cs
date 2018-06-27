using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SmogInfo.SmogLevelsLogic.Model;

namespace SmogInfo.SmogLevelsLogic
{
    public class DownloadDataFromApi
    {


        public GIOSList ReturnDataFromJson()
        {
            string JsonFromApi = Get("http://api.gios.gov.pl/pjp-api/rest/data/getData/3584");

            
            Console.WriteLine(JsonFromApi);
            
            
            var a = JsonConvert.DeserializeObject<GIOSList>(JsonFromApi);
            
            return a;
            
        }

        
        private string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        
        


    }
}
