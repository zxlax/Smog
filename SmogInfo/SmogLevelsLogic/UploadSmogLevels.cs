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
       

       
        
        

        public static void UploadDataToDatabase(GIOSList GIOSList)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:61614/api/cities/1/smogstation/1/level");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            string json = JsonConvert.SerializeObject(new SmogLevelForCreateDto()
            {
                DateTime = GIOSList.Values.ElementAt(1).Date,
                PM10Concentration = GIOSList.Values.ElementAt(1).Value.Value,

            });

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
               
                streamWriter.Write(json);
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
            RecurringJob.AddOrUpdate("id1", () => UploadDataToDatabase(GIOSList), Cron.Hourly);
            RecurringJob.Trigger("id1");
            BackgroundJob.Enqueue(() => UploadDataToDatabase(GIOSList));
        }
    }

   

}
