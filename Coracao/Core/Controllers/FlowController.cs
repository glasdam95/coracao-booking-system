using Coracao.Domain;
using Coracao.Domain.Models.InternalModels.FlowModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Coracao.Core.Controllers
{
    [Route("-/api/[controller]")]
    [ApiController]
    public class FlowController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly ICoracaoManager _coracaoManager;

        public FlowController(ILogger<AuthenticationController> logger, ICoracaoManager coracaoManager)
        {
            _logger = logger;
            this._coracaoManager = coracaoManager;
        }

        // Define the entire flow
        [HttpPost("booking")]
        public IActionResult Index([FromBody] BookingRequestModel bookingRequestModel)
        {
            if (bookingRequestModel == null)
            {
                var validationModelResponse = new BookingResponseModel
                {
                    Booking = false,
                    BookingMessage = "Model validation failed"
                };

                return BadRequest(validationModelResponse);
            }

            var bookingResponse = _coracaoManager.ExecuteNewBooking(bookingRequestModel);

            var bookingResponseModel = new BookingResponseModel
            {
                Booking = true,
                BookingMessage = ""
            };

            return Ok(bookingResponseModel);
        }
    }
}