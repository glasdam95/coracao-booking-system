namespace Coracao.Domain.Models.Abstractions
{
    public interface IAuthenticationRequestModel
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}