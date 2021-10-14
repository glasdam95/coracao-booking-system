using System.Text.Json.Serialization;
using Coracao.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Coracao.Controllers
{
    [Route("-/api/[controller]")]
    [ApiController]
    public class InformationController : Controller
    {
        private readonly ILogger<InformationController> _logger;
        private readonly ICoracaoManager _coracaoManager;

        public InformationController(ILogger<InformationController> logger, ICoracaoManager coracaoManager)
        {
            _logger = logger;
            this._coracaoManager = coracaoManager;
        }

        [HttpGet("getprofileinformation")]
        public IActionResult GetProfileInformation()
        {
            var simpletest = new
            {
                Name = "Magnus"
            };

            var serializedResponse = JsonConvert.SerializeObject(simpletest);

            return Ok(serializedResponse);
        }

        [HttpGet("getbookings")]
        public IActionResult GetBookings()
        {
            var simpletest = new
            {
                Provider = "Magnus"
            };

            var serializedResponse = JsonConvert.SerializeObject(simpletest);

            return Ok(serializedResponse);
        }
    }
}