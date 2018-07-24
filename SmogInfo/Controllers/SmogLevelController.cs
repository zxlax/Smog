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
    public class SmogLevelController : Controller
    {
        private ISmogInfoRepository _smogInfoRepository;
        public SmogLevelController(ISmogInfoRepository smogInfoRepository)
        {
            _smogInfoRepository = smogInfoRepository;
        }

        [HttpGet("{cityId}/smogStation/{stationId}/level", Name="GetSmogLevel")]
        public IActionResult GetLevels(int cityId, int stationId)
        {
            var levels = _smogInfoRepository.GetSmogLevels(cityId, stationId);
            if (levels == null) return NotFound();
            var result = Mapper.Map<IEnumerable<SmogLevelDto>>(levels);
           
            return Ok(result);
        }
        [HttpPost("{cityId}/smogStation/{stationId}/level")]
        public IActionResult CreateLevel(int cityId, int stationId,[FromBody]SmogLevelForCreateDto smogLevelForCreate)
        {
            if (smogLevelForCreate == null) return BadRequest();
            if (_smogInfoRepository.GetCity(cityId, false) == null) return NotFound();
            

            var smogLevelToAdd = Mapper.Map<Entities.SmogLevel>(smogLevelForCreate);
           

            _smogInfoRepository.AddSmogLevel(cityId, stationId, smogLevelToAdd);

            if (!_smogInfoRepository.Save()) return StatusCode(500);
            var createdSmogLevel = Mapper.Map<Model.SmogLevelDto>(smogLevelToAdd);
            

            return CreatedAtRoute("GetSmogLevel", new {cityId = cityId, stationId=stationId },createdSmogLevel);
        }



    }
}
