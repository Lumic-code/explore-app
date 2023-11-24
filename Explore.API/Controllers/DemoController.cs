using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Explore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly IStringLocalizer<DemoController> _loc;

        public DemoController(ILogger<DemoController> logger, IStringLocalizer<DemoController> loc)
        {
            _logger = logger;
            _loc = loc;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(_loc["hi"]);
           var message =  _loc["hi"].ToString();
            return Ok(message);
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var message = string.Format(_loc["welcome"], name);
            return Ok(message);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var message = _loc.GetAllStrings();
            return Ok(message);
        }
    }
}
