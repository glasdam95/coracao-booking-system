namespace Coracao.Domain.Models.InternalModels
{
    public class AuthenticationResultModel
    {
        public string ErrorDeterminer { get; set; }
        public string ResponseMessage { get; set; }
        public string FlowToken { get; set; }
    }
}