using Microsoft.AspNetCore.Mvc;
using SmogInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmogInfo.Controllers
{
    [Route("api/cities")]
    public class SmogController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {

            return Ok(SmogDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var CityToReturn = SmogDataStore.Current.Cities.FirstOrDefault(i => i.ID == id);
            if (CityToReturn == null)
            {
                return NotFound();
            }
            return Ok(CityToReturn);
        }


    }
}
