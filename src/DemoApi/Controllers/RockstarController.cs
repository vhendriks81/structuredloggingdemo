using System.Collections.Generic;
using DemoApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApi.Controllers
{
    using DemoApi.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class RockstarController : ControllerBase
    {
        private readonly ILogger<RockstarController> _logger;
        private readonly IDemoService _demoService;

        public RockstarController(ILogger<RockstarController> logger, IDemoService demoService)
        {
            _logger = logger;
            _demoService = demoService;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Rockstar>> Get()
        {
            return Ok(_demoService.GetAllRockstars());
        }

        [HttpGet("random")]
        public ActionResult<Rockstar> GetRandom()
        {
            return Ok(_demoService.GetRandomRockstar());
        }

        [HttpGet("sendToRandom")]
        public ActionResult SendToRandom()
        {
            var rockstar = _demoService.GetRandomRockstar();

            _demoService.MessageRockstar(rockstar, "Message from controller");

            return Ok();
        }
    }
}
