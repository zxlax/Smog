using Microsoft.AspNetCore.Mvc;
using SmogInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Controllers
{
    public class DummyController:Controller
    {
        private SmogInfoContext _ctx;
        
        public DummyController(SmogInfoContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }



    }
}
