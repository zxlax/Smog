using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmogInfo.Model;

namespace SmogInfo.Controllers
{

    [Route("api/cities")]
    public class StationPointController : Controller
    { 

        [HttpGet("{cityId}/smogStation")]
        public IActionResult GetStation(int cityId)
        {
            var city = SmogDataStore.Current.Cities.FirstOrDefault(i => i.ID == cityId);
            if (city == null) return NotFound();
            return Ok(city.StationPoints);
        }

        [HttpGet("{cityId}/smogStation/{stationId}")]
        public IActionResult GetStation(int cityId, int stationId)
        {
            var city = SmogDataStore.Current.Cities.FirstOrDefault(i => i.ID == cityId);
            if (city == null) return NotFound();

            var station = city.StationPoints.FirstOrDefault(i => i.ID == stationId);
            if (station == null) return NotFound();
            return Ok(station);
        }


    }
}
