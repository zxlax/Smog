using Microsoft.AspNetCore.Mvc;
using SmogInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Controllers
{
    [Route("api/cities")]
    public class SmogLevelController : Controller
    {
        [HttpGet("{cityId}/smogStation/{stationId}/level")]
        public IActionResult GetLevels(int cityId, int stationId)
        {
            var city = SmogDataStore.Current.Cities.FirstOrDefault(i => i.ID == cityId);
            if (city == null) return NotFound();

            var station = city.StationPoints.FirstOrDefault(i => i.ID == stationId);
            if (station == null) return NotFound();
            return Ok(station.SmogLevels);
        }



    }
}
