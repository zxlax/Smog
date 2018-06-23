using SmogInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Services
{
    public interface ISmogInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int CityId, bool includeStationPoints);

        IEnumerable<StationPoint> GetStationPoints(int CityId);
        StationPoint GetStationPoint(int CityId,int StationId);

        IEnumerable<SmogLevel> GetSmogLevels(int CityId, int StationId);

        void AddSmogLevel(int cityId, int stationId, SmogLevel smogLevel);
        bool Save();
        

       
    }
}
