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
            throw new NotImplementedException();
        }



    }
}
