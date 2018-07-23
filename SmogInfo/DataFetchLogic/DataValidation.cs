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

        public GIOSList CheckForNull(GIOSList list)
        {
            GIOSList _list = new GIOSList{Key =list.Key, Values = list.Values.Where(i => i.Value != null).ToList()};
            return _list;
           
        }

        public IEnumerable<SmogLevel> TranslateDataToSmogLevel(GIOSList list)
        {
            List<SmogLevel> data = new List<SmogLevel>();
            foreach (var item in list.Values)
            {
                data.Add(new SmogLevel() { DateTime = item.Date, PM10Concentration = item.Value.Value, StationPointId = 1 });
            }
            return data;
        }

        public IEnumerable<SmogLevel> DataFromDatabase(int cityId, int stationId)
        {
            var levels = _smogInfoRepository.GetSmogLevels(cityId, stationId);
            return levels;
        }

        public IEnumerable<SmogLevel> ActualValidation(GIOSList list, IEnumerable<SmogLevel> levels)
        {
            IEnumerable<SmogLevel> smogs = TranslateDataToSmogLevel(list);

            var newItems = smogs.Where(x => !levels.Any(y => x.DateTime == y.DateTime));


            return newItems;
            

        }




        public void testAdd(IEnumerable<SmogLevel> levels)
        {
            foreach (var item in levels)
            {
                _smogInfoRepository.AddSmogLevel(1, 1, item);
                _smogInfoRepository.Save();
            }
            
        }
        


    }

    public class DeserializeException : Exception
    {

    }



}
