using Coracao.Domain;
using Coracao.Domain.Models.InternalModels;
using Coracao.Domain.Models.RequestsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Coracao.Core.Controllers
{
    [Route("-/api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly ICoracaoManager _coracaoManager;

        public AuthenticationController(ILogger<AuthenticationController> logger, ICoracaoManager coracaoManager)
        {
            _logger = logger;
            this._coracaoManager = coracaoManager;
        }

        [HttpPost("login")]
        //[ValidateAntiForgeryToken]
        public IActionResult Login([FromBody] AuthenticationRequestModel authenticationModel)
        {
            if (authenticationModel == null)
            {
                var responseFailedModel = new LoginResponse
                {
                    Authentication = false,
                    Message = "Model Validation Errors"
                };
                return BadRequest(responseFailedModel);
            }

            var loginResponse = _coracaoManager.ExecuteLogin(authenticationModel).Result;

            if (loginResponse.ErrorDeterminer == "Information")
            {
                var responseFailedLogin = new LoginResponse
                {
                    Authentication = false,
                    Message = loginResponse.ResponseMessage
                };
                return BadRequest(responseFailedLogin);
            }

            //session.AuthenticationToken = testObject.AuthenticationToken;

            var response = new LoginResponse
            {
                Authentication = true,
                Message = "Success",
                FlowToken = loginResponse.FlowToken
            };

            return Ok(response);
        }

        [HttpGet("logout")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            var testObject = new
            {
                Logout = "Success"
            };

            var serializedObject = JsonConvert.SerializeObject(testObject);

            return Ok(serializedObject);
        }
    }
}