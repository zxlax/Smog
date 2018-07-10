using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.SmogLevelsLogic
{
    public class DataProcessing
    {
        private static DownloadDataFromApi DownloadDataFromApi;
        private static UploadSmogLevels UploadSmogLevels;

        public static void CyclicTask()
        {
            DownloadDataFromApi = new DownloadDataFromApi();
            UploadSmogLevels = new UploadSmogLevels();
            UploadSmogLevels.CyclicTask(DownloadDataFromApi.ReturnDataFromJson("http://api.gios.gov.pl/pjp-api/rest/data/getData/3584"));
        }

        public static void Run()
        {
            RecurringJob.AddOrUpdate("id1", () => CyclicTask(), Cron.Hourly);
            RecurringJob.Trigger("id1");
        }
      

    }
}
