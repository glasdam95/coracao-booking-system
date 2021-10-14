using System.Threading.Tasks;
using Coracao.Domain.Models.RequestsModels;
using Coracao.Domain.Models.ResponseModels;

namespace Coracao.Domain.Managers.Abstractions
{
    public interface ICommunicationManager
    {
        void InitializeHeaders();
        Task<string> GetRequest(GenericReqeustModel model);
        Task<GenericResponseModel> PostRequest(GenericReqeustModel model);
    }
}