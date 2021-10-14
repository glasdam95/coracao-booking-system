using System;
using System.Collections.Generic;
using System.Linq;
using Coracao.Domain.Models.Abstractions;
using System.Threading.Tasks;
using Coracao.Domain.Managers;
using Coracao.Domain.Managers.Abstractions;
using Coracao.Domain.Models.HelperModels;
using Coracao.Domain.Models.InternalModels;
using Coracao.Domain.Models.InternalModels.FlowModels;
using Coracao.Domain.Models.RequestsModels;
using Coracao.Domain.Models.ResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Coracao.Domain
{
    public class CoracaoManager : ICoracaoManager
    {
        private readonly ICommunicationManager _communicationManager;
        public static ISessionManager SessionManager = new SessionManager();
        private readonly IConstructionModelManager _constructionModelManager = new ConstructionModelManager(SessionManager);

        public CoracaoManager(ICommunicationManager communicationManager)
        {
            _communicationManager = communicationManager;
        }

        public void InitializeCommunicationManager()
        {
            _communicationManager.InitializeHeaders();
        }

        public async Task<AuthenticationResultModel> ExecuteLogin(IAuthenticationRequestModel authenticationModel)
        {
            GenericReqeustModel preLoadedModel = _constructionModelManager.CreatePreLoadingModel();

            var preLoadedResponse = await _communicationManager.PostRequest(preLoadedModel);

            SessionManager.FlowToken = preLoadedResponse?.Header?.aDDODefs.FirstOrDefault()?.sCS;

            GenericReqeustModel conformedAuthenticationModel = _constructionModelManager.CreateAuthenticationModel(authenticationModel);

            var authenticationResponse = await _communicationManager.PostRequest(conformedAuthenticationModel);

            var responseModel = new AuthenticationResultModel
            {
                ResponseMessage = authenticationResponse?.Header?.aActions.FirstOrDefault()?.aParams[0],
                ErrorDeterminer = authenticationResponse?.Header?.aActions.FirstOrDefault()?.aParams[1],
                FlowToken = authenticationResponse?.Header?.aDDODefs.FirstOrDefault()?.sCS
            };
            
            return responseModel;
        }

        public async Task<BookingResultModel> ExecuteNewBooking(BookingRequestModel bookingRequestModel)
        {
            List<RequestResponseModels.Addodef> defsList = null;

            //Step 1 - Initialize with session token
            GenericReqeustModel initializationRequestModel = _constructionModelManager.CreateInitializationRequestModel();
            var preLoadedResponse = await _communicationManager.PostRequest(initializationRequestModel);
            defsList = ExtractDefsList(preLoadedResponse);

            //Step 2 - OnShow
            GenericReqeustModel onShowRequestModel = _constructionModelManager.CreateOnShowRequestModel(defsList);
            var onShowLoadedResponse = await _communicationManager.PostRequest(onShowRequestModel);
            defsList = ExtractDefsList(onShowLoadedResponse);

            //Step 3 - BookingView - Extract and save andelsnummer - Extract Year and Apartments for selection
            GenericReqeustModel bookingViewRequestModel = _constructionModelManager.CreateBookingViewRequestModel(defsList);
            var bookingViewLoadedResponse = await _communicationManager.PostRequest(bookingViewRequestModel);
            defsList = ExtractDefsList(bookingViewLoadedResponse);

            //Step 4 - Extract - Extract Andels Number and Parents name
            GenericReqeustModel step4M = _constructionModelManager.CreateInitialBookingRequestModel(defsList);
            var step4R = await _communicationManager.PostRequest(step4M);
            defsList = ExtractDefsList(step4R, "oBookLejl");

            //Step 5 - Initialize Booking - Investigate error
            GenericReqeustModel initializeBookingRequestModel = _constructionModelManager.CreateNewBookingRequestModel(defsList);
            var initializeBookingResponse = await _communicationManager.PostRequest(initializeBookingRequestModel);
            defsList = ExtractDefsList(initializeBookingResponse);
            var asyncprops = initializeBookingResponse.Header?.aSyncProps;

            //Step 6 - Initialize Booking
            GenericReqeustModel decideWeekBookingRequestModel = _constructionModelManager.CreateDecideBookingRequestModel(defsList, asyncprops);

            var newDecideWeekBookingRequestModel = EditRequestModel(decideWeekBookingRequestModel, "33", "oBookLejl.oWebMainPanel.oBookOversigt.oBook_uge");

            var decideBookingResponse = await _communicationManager.PostRequest(newDecideWeekBookingRequestModel);
            defsList = ExtractDefsList(decideBookingResponse);

            // Step 7 - 
            GenericReqeustModel finalBookingRequestModel = _constructionModelManager.CreateFinalBookingRequestModel(defsList);
            var finalBookingResponse = await _communicationManager.PostRequest(finalBookingRequestModel);
            defsList = ExtractDefsList(finalBookingResponse);


            // Step 8 - 
            GenericReqeustModel confirmBookingRequestModel = _constructionModelManager.CreateConfirmBookingRequestModel(defsList);
            var confirmBookingResponse = await _communicationManager.PostRequest(confirmBookingRequestModel);

            var bookingResult = new BookingResultModel
            {

            };

            return bookingResult;
        }

        private GenericReqeustModel EditRequestModel(GenericReqeustModel decideWeekBookingRequestModel, string value, string reference)
        {
            foreach (var props in decideWeekBookingRequestModel.ActionRequest.Header.aSyncProps)
            {
                if (props.sO == reference)
                {
                    if (props.aP != null)
                    {
                        props.aP[0].sV = value;
                        props.aP[1].sV = "1";
                    }
                }
            }

            return decideWeekBookingRequestModel;
        }

        private static List<RequestResponseModels.Addodef> ExtractDefsList(GenericResponseModel decideBookingResponse,
            string focusElement = null)
        {
            List<RequestResponseModels.Addodef> defsList = new List<RequestResponseModels.Addodef>();
            if (decideBookingResponse?.Header != null)
                foreach (var defs in decideBookingResponse?.Header?.aDDODefs)
                {
                    if (focusElement != null)
                    {
                        if (focusElement == defs?.sView)
                        {
                            defsList.Add(defs);
                        }
                    }
                    else
                    {
                        defsList.Add(defs);
                    }
                }

            return defsList;
        }

        private string RetrieveTokenFromRequest(List<RequestResponseModels.Addodef?> headerADdoDefs, string key)
        {
            foreach (var tokenObject in headerADdoDefs)
            {
                if (tokenObject?.sView == key)
                {
                    return tokenObject?.sCS;
                }
            }

            return null;
        }
    }
}