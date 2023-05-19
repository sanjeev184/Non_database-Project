using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Non_database_Project.Model;
using Non_database_Project.Repolayer;
using Non_database_Project.Servicelayer;
using System.Collections.Generic;

namespace Non_database_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketController : ControllerBase
    {
        public ICricketerRepo _cricketerService;

        public CricketController(ICricketerRepo cricketerService)
        {
            //_cricketerService = cricketerService;
            _cricketerService = cricketerService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var display = _cricketerService.GetAll();
            return Ok(display);
        }

        [HttpGet]
        public ActionResult GetId(int id)
        {
            if (id == 0)
                return NotFound();
            var display = _cricketerService.Get(id);

            if (display == null)
                return NotFound();
            return Ok(display);
        }

        [HttpPost]
        public IActionResult Insert(CricketTeam cricketTeam)
        {
            var Insert = _cricketerService.Add(cricketTeam);

            if (Insert == null)
            {
                return NotFound();
            }
            return Ok(Insert);

        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {

            _cricketerService.Remove(id);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Update(CricketTeam cricketTeam)
        {

            var cricketteam = _cricketerService.Update(cricketTeam);

            return Ok(cricketteam);
        }
    }
}
