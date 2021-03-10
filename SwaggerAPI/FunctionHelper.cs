using RestSharp;
using SwaggerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerAPI
{
    public class FunctionHelper<T>
    {
        public ListOfPets getPet(string endpoint)
        {
            var apiHelpObject = new APIHelper<ListOfPets>();
            var restClient = apiHelpObject.setUrl(endpoint);
            var restRequest = apiHelpObject.getMethod("85");
            var response = apiHelpObject.getResponse(restClient, restRequest);
            var content = apiHelpObject.getContent<ListOfPets>(response);
            return content;
        }

        public IRestResponse creatPets(string endpoint, Pet payload)
        {
            var user = new APIHelper<Pet>();
            var url = user.setUrl(endpoint);
            var request = user.postMethod(payload);
            var response = user.getResponse(url, request);
            return response;     
        }

        public UpdatePet updatePet(string endpoint, string payload)
        {
            var apiHelpObject = new APIHelper<UpdatePet>();
            var restClient = apiHelpObject.setUrl(endpoint);
            var request = apiHelpObject.putMethod(payload);
            var response = apiHelpObject.getResponse(restClient, request);
            UpdatePet userDTO = apiHelpObject.getContent<UpdatePet>(response);
            return userDTO;
        }

        public IRestResponse deletePet(string endpoint)
        {
            var apiHelpObject = new APIHelper<ListOfPets>();
            var restClient = apiHelpObject.setUrl(endpoint);
            var restRequest = apiHelpObject.deleteMethod("85");
            var response = apiHelpObject.getResponse(restClient, restRequest);
            return response;           
        }
    }
}
