namespace Coracao.Domain
{
    public class SessionManager : ISessionManager
    {
        public string AuthenticationToken { get; set; }
        public string FlowToken { get; set; }
        public string GetAutheticationToken()
        {
            throw new System.NotImplementedException();
        }

        public string GetFlowToken()
        {
            throw new System.NotImplementedException();
        }
    }
}