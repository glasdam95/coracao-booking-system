namespace Coracao.Domain.Models.InternalModels
{
    public class LoginResponse
    {
        public bool Authentication { get; set; }
        public string Message { get; set; }
        public string FlowToken { get; set; }
    }
}