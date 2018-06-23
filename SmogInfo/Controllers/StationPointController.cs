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
        public IActionResult GetStations(int cityId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{cityId}/smogStation/{stationId}")]
        public IActionResult GetStation(int cityId, int stationId)
        {
            throw new NotImplementedException();
        }


    }
}
