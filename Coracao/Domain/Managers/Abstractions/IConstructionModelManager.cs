using System.Collections.Generic;
using Coracao.Domain.Models.Abstractions;
using Coracao.Domain.Models.HelperModels;
using Coracao.Domain.Models.RequestsModels;
using Coracao.Domain.Models.ResponseModels;

namespace Coracao.Domain.Managers.Abstractions
{
    public interface IConstructionModelManager
    {
        GenericReqeustModel CreateAuthenticationModel(IAuthenticationRequestModel authenticationModel);
        GenericReqeustModel CreatePreLoadingModel();
        GenericReqeustModel CreateInitializationRequestModel();
        GenericReqeustModel CreateOnShowRequestModel(List<RequestResponseModels.Addodef> defsList);
        GenericReqeustModel CreateBookingViewRequestModel(List<RequestResponseModels.Addodef> defsList);
        GenericReqeustModel CreateNewBookingRequestModel(List<RequestResponseModels.Addodef> defsList);
        GenericReqeustModel CreateInitialBookingRequestModel(List<RequestResponseModels.Addodef> defsList);
        GenericReqeustModel CreateDecideBookingRequestModel(List<RequestResponseModels.Addodef> aDdOs,
            List<RequestResponseModels.Asyncprop?> asyncprops);
        GenericReqeustModel CreateFinalBookingRequestModel(List<RequestResponseModels.Addodef> addodef);
        GenericReqeustModel CreateConfirmBookingRequestModel(List<RequestResponseModels.Addodef> addoFinalStep);
    }
}