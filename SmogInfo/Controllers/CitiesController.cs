using Microsoft.AspNetCore.Mvc;
using SmogInfo.Model;
using SmogInfo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmogInfo.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ISmogInfoRepository _smogInfoRepository;
        public CitiesController(ISmogInfoRepository smogInfoRepository)
        {
            _smogInfoRepository = smogInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            var cities = _smogInfoRepository.GetCities();
            var result = new List<CitiesWithoutStationsDto>();

            foreach(var i in cities)
            {
                result.Add(new CitiesWithoutStationsDto()
                {
                    ID = i.Id,
                    CityName = i.CityName,

                });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includeStationPoints = false)
        {
            var city = _smogInfoRepository.GetCity(id, includeStationPoints);
            if (city == null) return NotFound();
            if(includeStationPoints)
            {
                var cityResult = new CitiesDto()
                {
                    ID = city.Id,
                    CityName = city.CityName
                };
                foreach (var station in city.StationPoints)
                    cityResult.StationPoints.Add(
                        new StationPointDto()
                        {
                            ID = station.ID,
                            StreetName = station.StreetName,

                        });
                return Ok(cityResult);

            } else
            {
                var cityResult = new CitiesWithoutStationsDto()
                {
                    ID = city.Id,
                    CityName = city.CityName
                };

                return Ok(cityResult);
            }
                
            


        }


    }
}
