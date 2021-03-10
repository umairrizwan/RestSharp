using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerAPI
{
    public class APIHelper<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://petstore.swagger.io/v2";

        public RestClient setUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest getMethod(string petId)
        {
            restRequest =  new RestRequest(Method.GET);
            restRequest.AddUrlSegment("petId", petId);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest deleteMethod(string petId)
        {
            restRequest = new RestRequest(Method.DELETE);
            restRequest.AddUrlSegment("petId", petId);
            return restRequest;
        }

        public RestRequest postMethod(Object payload)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("ContentType", "application/json");          
            restRequest.AddJsonBody(payload);
            return restRequest;
        }

        public RestRequest putMethod(string payload)
        {
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddJsonBody(payload);
            return restRequest;
        }

        public IRestResponse getResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO getContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO DTOObjects = JsonConvert.DeserializeObject<DTO>(content);
            return DTOObjects;
        }
    }
}
