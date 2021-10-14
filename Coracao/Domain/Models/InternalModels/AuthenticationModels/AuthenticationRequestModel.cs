using Coracao.Domain.Models.Abstractions;
using Newtonsoft.Json;

namespace Coracao.Domain.Models.RequestsModels
{
    public class AuthenticationRequestModel : IAuthenticationRequestModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}