using System.Threading.Tasks;
using Coracao.Domain.Models.Abstractions;
using Coracao.Domain.Models.InternalModels;
using Coracao.Domain.Models.InternalModels.FlowModels;

namespace Coracao.Domain
{
    public interface ICoracaoManager
    {
        void InitializeCommunicationManager();
        Task<AuthenticationResultModel> ExecuteLogin(IAuthenticationRequestModel authenticationModel);
        Task<BookingResultModel> ExecuteNewBooking(BookingRequestModel bookingRequestModel);
    }
}