namespace Coracao.Domain
{
    public interface ISessionManager
    {
        string AuthenticationToken { get; set; }
        string FlowToken { get; set; }

        string GetAutheticationToken();
        string GetFlowToken();
    }
}