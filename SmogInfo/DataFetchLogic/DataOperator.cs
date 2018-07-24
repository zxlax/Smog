using SmogInfo.Entities;
using SmogInfo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.DataFetchLogic
{
    public class DataOperator
    {
        private SmogInfoContext _smogInfoContext;
        public DataOperator(SmogInfoContext smogInfoContext)
        {
            _smogInfoContext = smogInfoContext;
        }

        public void StartFrequentDataOperating(string url, int city, int station)
        {
            ISmogInfoRepository smogInfoRepository = new SmogInfoRepository(this._smogInfoContext);

            var dataFetch = new DataFetch();

            var dataValidation = new DataValidation(smogInfoRepository);

            var dataUpload = new DataUpload(smogInfoRepository);

            var data = dataFetch.ReturnData(url);

            var deserializedData = dataValidation.Deserialize(data);

            var checkedForNull = dataValidation.CheckForNull(deserializedData);

            var translatedData = dataValidation.TranslateDataToSmogLevel(checkedForNull);

            var dataFromDatabase = smogInfoRepository.GetSmogLevels(city, station);

            var endData = dataValidation.ValidateData(translatedData, dataFromDatabase);

            dataUpload.UploadData(endData);

            Console.WriteLine("DataCompared ----->  " + DateTime.Now.ToString());
        }



        

        
        
      






    }
}
