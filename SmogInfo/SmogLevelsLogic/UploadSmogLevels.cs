using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Hangfire;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using SmogInfo.Model;
using SmogInfo.SmogLevelsLogic.Model;

namespace SmogInfo.SmogLevelsLogic
{
    public class UploadSmogLevels
    {
       

       
        
        

        public static void UploadDataToDatabase(string URIToUpdate, string JsonToUpdate)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URIToUpdate);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
           

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
               
                streamWriter.Write(JsonToUpdate);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

        }

        public static void CyclicTask(GIOSList GIOSList)
        {
            string json = JsonConvert.SerializeObject(new SmogLevelForCreateDto()
            {
                DateTime = GIOSList.Values.ElementAt(2).Date,
                PM10Concentration = GIOSList.Values.ElementAt(2).Value.Value,

            });
            UploadDataToDatabase("http://localhost:61614/api/cities/1/smogstation/1/level",json);
            
        }
    }

   

}
