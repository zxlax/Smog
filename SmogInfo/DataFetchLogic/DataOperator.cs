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

        public void StartFrequentDataOperating(string url10,string url25, int city, int station)
        {
            ISmogInfoRepository smogInfoRepository = new SmogInfoRepository(this._smogInfoContext);

            var dataFetch = new DataFetch();

            var dataValidation = new DataValidation(smogInfoRepository);

            var dataUpload = new DataUpload(smogInfoRepository);

            var data10 = dataFetch.ReturnData(url10);
            var data25 = dataFetch.ReturnData(url25);

            var deserializedData10 = dataValidation.Deserialize(data10);
            var deserializedData25 = dataValidation.Deserialize(data25);

            var checkedForNull10 = dataValidation.CheckForNull(deserializedData10);
            var checkedForNull25 = dataValidation.CheckForNull(deserializedData25);

            var translatedData10 = dataValidation.TranslateDataToSmogLevel10(checkedForNull10);
            var translatedData25 = dataValidation.TranslateDataToSmogLevel25(checkedForNull25);

            var joinedData = dataValidation.JoinLevels(translatedData10, translatedData25);
            //joined data tu powinno byc

            var dataFromDatabase = smogInfoRepository.GetSmogLevels(city, station);

            var endData = dataValidation.ValidateData(joinedData, dataFromDatabase);

            dataUpload.UploadData(endData);

            Console.WriteLine("DataCompared ----->  " + DateTime.Now.ToString());
        }



        

        
        
      






    }
}
