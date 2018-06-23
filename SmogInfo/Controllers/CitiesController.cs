using AutoMapper;
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
            var result = Mapper.Map<IEnumerable<CitiesWithoutStationsDto>>(cities);
            

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includeStationPoints = false)
        {
            var city = _smogInfoRepository.GetCity(id, includeStationPoints);
            if (city == null) return NotFound();
            if(includeStationPoints)
            {
                var cityResult = Mapper.Map<CitiesDto>(city);
                
                return Ok(cityResult);

            } else
            {
                var cityResult = Mapper.Map<CitiesWithoutStationsDto>(city);
               
                return Ok(cityResult);
            }
                
            


        }


    }
}
