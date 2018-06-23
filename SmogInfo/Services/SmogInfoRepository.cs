using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmogInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace SmogInfo.Services
{
    public class SmogInfoRepository : ISmogInfoRepository
    {
        private SmogInfoContext _context;
        public SmogInfoRepository(SmogInfoContext context)
        {
            _context = context;
        }

        public void AddSmogLevel(int cityId, int stationId, SmogLevel smogLevel)
        {
            var station = GetStationPoint(cityId, stationId);
            station.SmogLevels.Add(smogLevel);
            
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.CityName).ToList();
        }

        public City GetCity(int CityId, bool inculdeStationPoints)
        {
            if (inculdeStationPoints)
                return _context.Cities.Include(p => p.StationPoints).Where(i => i.Id == CityId).FirstOrDefault();
            else
                return _context.Cities.Where(i => i.Id == CityId).FirstOrDefault();
        }

      
        

        public IEnumerable<SmogLevel> GetSmogLevels(int CityId, int StationId)
        {
            
            return _context.SmogLevels.Where(p=>p.StationPoint.ID==StationId&&p.StationPoint.CityId==CityId).OrderBy(c=>c.DateTime).ToList();
        
        }

        public StationPoint GetStationPoint(int CityId, int StationId)
        {
            return _context.StationPoints.Where(p => p.CityId == CityId && p.ID == StationId).FirstOrDefault();
        }

        public IEnumerable<StationPoint> GetStationPoints(int CityId)
        {
            return _context.StationPoints.Where(p => p.CityId == CityId).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
