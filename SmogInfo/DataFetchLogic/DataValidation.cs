using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SmogInfo.SmogLevelsLogic.Model;
using SmogInfo.Services;
using SmogInfo.Entities;

namespace SmogInfo.DataFetchLogic
{
    public class DataValidation
    {
        private ISmogInfoRepository _smogInfoRepository;
        public DataValidation(ISmogInfoRepository smogInfoRepository)
        {
            _smogInfoRepository = smogInfoRepository;
        }
        
        //deserializuje jsona 
        public GIOSList Deserialize(string data)
        {
            GIOSList _list;
            try
            {
                _list = JsonConvert.DeserializeObject<GIOSList>(data);
            }
             catch(DeserializeException) { return null; }

            return _list;
        }

        //sprawdza czy są nulle w kolekcji i się ich pozbywa
        public GIOSList CheckForNull(GIOSList list)
        {
            GIOSList _list = new GIOSList{Key =list.Key, Values = list.Values.Where(i => i.Value != null).ToList()};
            return _list;
           
        }

        //przerabia model z obcego api na mój //pm10
        public IEnumerable<SmogLevel> TranslateDataToSmogLevel10(GIOSList list)
        {
            List<SmogLevel> data = new List<SmogLevel>();
            foreach (var item in list.Values)
            {
                data.Add(new SmogLevel() { DateTime = item.Date, PM10Concentration = item.Value.Value, StationPointId = 1 });
            }
            return data;
        }

        //przerabia model z obcego api na mój //pm2.5
        public IEnumerable<SmogLevel> TranslateDataToSmogLevel25(GIOSList list)
        {
            List<SmogLevel> data = new List<SmogLevel>();
            foreach (var item in list.Values)
            {
                data.Add(new SmogLevel() { DateTime = item.Date, PM25Concentration = item.Value.Value, StationPointId = 1 });
            }
            return data;
        }

        //lipnie łączy sobie pm10 i pm2.5
        public IEnumerable<SmogLevel> JoinLevels(IEnumerable<SmogLevel> levels10, IEnumerable<SmogLevel> levels25)
        {
            var transformedList = new List<SmogLevel>();

            foreach (var item in levels10)
            {
                item.PM25Concentration = levels25.Where(i => item.DateTime == i.DateTime).FirstOrDefault().PM25Concentration; 
               
            }

            return levels10;
        }


        //pobiera dane z mojej bazy danych
        public IEnumerable<SmogLevel> DataFromDatabase(int cityId, int stationId)
        {
            var levels = _smogInfoRepository.GetSmogLevels(cityId, stationId);
            return levels;
        }



        //porównuje dane z mojej bazy danych i api i zwraca te które się nie powtarzają
        public IEnumerable<SmogLevel> ValidateData(IEnumerable<SmogLevel> smogs, IEnumerable<SmogLevel> levels)
        {

            var newItems = smogs.Where(x => !levels.Any(y => x.DateTime == y.DateTime));


            return newItems;
            

        }

        



        


    }

    public class DeserializeException : Exception
    {

    }



}
