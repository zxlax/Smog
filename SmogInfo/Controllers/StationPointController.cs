using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmogInfo.Model;
using SmogInfo.Services;

namespace SmogInfo.Controllers
{

    [Route("api/cities")]
    public class StationPointController : Controller
    {
        private ISmogInfoRepository _smogInfoRepository;
        public StationPointController(ISmogInfoRepository smogInfoRepository)
        {
            _smogInfoRepository = smogInfoRepository;
        }


        [HttpGet("{cityId}/smogStation")]
        public IActionResult GetStations(int cityId)
        {

            var stations = _smogInfoRepository.GetStationPoints(cityId);
            if (stations == null) return NotFound();
            var result = new List<StationPointDto>();
            foreach(var stat in stations)
            {
                result.Add(new StationPointDto()
                {
                    ID = stat.ID,
                    StreetName = stat.StreetName
                });
                
            }
            return Ok(result);
        }

        [HttpGet("{cityId}/smogStation/{stationId}")]
        public IActionResult GetStation(int cityId, int stationId)
        {
            var station = _smogInfoRepository.GetStationPoint(cityId, stationId);
            if (station == null) return NotFound();
            var result = new StationPointDto()
            {
                ID = station.ID,
                StreetName = station.StreetName
            };
            return Ok(result);
        }


    }
}
