using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Coracao.Domain.Managers.Abstractions;
using Coracao.Domain.Models.RequestsModels;
using Coracao.Domain.Models.ResponseModels;
using Newtonsoft.Json;

namespace Coracao.Domain.Managers
{
    public class CommunicationManager : ICommunicationManager
    {
        public HttpClient Client = new HttpClient();

        public CommunicationManager()
        {
            InitializeHeaders();
        }

        public void InitializeHeaders()
        {
            var dfWebApp = Guid.NewGuid();

            Client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            Client.DefaultRequestHeaders.Add("Accept", "*/*");
            Client.DefaultRequestHeaders.Add("Origin", "https://www.coracaobooking.dk");
            Client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
            Client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
            Client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
            Client.DefaultRequestHeaders.Add("Referer", "https://www.coracaobooking.dk/");
            Client.DefaultRequestHeaders.Add("Cookie", "ASPSESSIONIDCQRRCATR=AGEPCEKDKDFAGABKDMHCNBLL");
            //Client.DefaultRequestHeaders.Add("Cookie", $"dfWebApp={dfWebApp}");
        }

        public async Task<string> GetRequest(GenericReqeustModel model)
        {
            var serializedModel = JsonConvert.SerializeObject(model);

            var requestContent = new StringContent(
                serializedModel,
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await Client.PostAsync("http://www.example.com/recepticle.aspx", requestContent);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<GenericResponseModel> PostRequest(GenericReqeustModel model)
        {
            var serializedModel = JsonConvert.SerializeObject(model);

            var requestContent = new StringContent(
                serializedModel,
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await Client.PostAsync("https://www.coracaobooking.dk/WebServiceDispatcher.wso/CallAction/JSON", requestContent);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var deserializationResponse = JsonConvert.DeserializeObject<GenericResponseModel>(responseString);

            return deserializationResponse;
        }
    }
}