using HastaneOtomasyonu.WebUI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyonu.WebUI.Service
{
    public class RemoteService<T> where T:class
    {
        public string uri { get; set; }
        public RemoteService()
        {
            uri = "https://localhost:44394/api";
        }

        public ServiceResponse<T> Get(string controller, string action = null)
        {
            string url = uri + "/" + controller;
            if (action != null)
                url += "/" + action;

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse<ServiceResponse<T>> response = client.Execute<ServiceResponse<T>>(request);

            return response.Data;
        }

        public ServiceResponse<T> GetById(int id, string controller, string action = null)
        {
            string url = uri + "/" + controller;
            if (action != null)
                url += "/" + action;
            url += "/" + id;
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse<ServiceResponse<T>> response = client.Execute<ServiceResponse<T>>(request);

            return response.Data;
        }

        public ServiceResponse<T> GetByObj(object obj, string controller, string action = null)
        {
            string url = uri + "/" + controller;
            if (action != null)
                url += "/" + action;

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            string json = JsonConvert.SerializeObject(obj);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse<ServiceResponse<T>> response = client.Execute<ServiceResponse<T>>(request);

            return response.Data;
        }

        public ServiceResponse<T> Post(object obj,string controller, string action=null)
        {
            string url = uri + "/" + controller;
            if (action != null)
                url += "/" + action;
           
            string json = JsonConvert.SerializeObject(obj);
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse<ServiceResponse<T>> response = client.Execute<ServiceResponse<T>>(request);
            return response.Data;
        }

    }
}
