using SmogInfo.Entities;
using SmogInfo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.DataFetchLogic
{
    public class DataUpload
    {
        private ISmogInfoRepository _smogInfoRepository;
        public DataUpload(ISmogInfoRepository smogInfoRepository)
        {
            _smogInfoRepository = smogInfoRepository;
        }

      
            public void UploadData(IEnumerable<SmogLevel> smogLevels)
            {

                foreach (var item in smogLevels)
                {
                  _smogInfoRepository.AddSmogLevel(1, 1, item);
                  _smogInfoRepository.Save();
                 }
    
            }

           

        }




    
}
