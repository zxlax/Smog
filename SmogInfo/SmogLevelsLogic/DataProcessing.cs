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

        public static void Run()
        {
            DownloadDataFromApi = new DownloadDataFromApi();
            UploadSmogLevels = new UploadSmogLevels();
            UploadSmogLevels.CyclicTask(DownloadDataFromApi.ReturnDataFromJson());
        }
      

    }
}
