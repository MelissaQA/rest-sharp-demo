using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpDemo.Entities
{
    public class ProductRequests
    {
        private IRestClient restClient { get; set; }

        public ProductRequests() 
        {
            this.restClient = new RestClient();
            this.restClient.Authenticator = new HttpBasicAuthenticator("shopmanager", "axY2 rimc SzO9 cobf AZBw NLnX");
        }

        public string CreateProduct(string url, string jsonData) 
        {
            IRestRequest postRequest = new RestRequest(url);
            postRequest.AddHeader("Accept", "application/json");

            postRequest.AddJsonBody(jsonData);
            IRestResponse postResponse = restClient.Post(postRequest);

            Console.WriteLine(postResponse.StatusCode);
            Console.WriteLine(postResponse.Content);

            return postResponse.Content;

        }

        public string DeleteProduct(string url) 
        {
            IRestRequest deleteRequest = new RestRequest(url);
            IRestResponse deleteResponse = restClient.Delete(deleteRequest);

            Console.WriteLine(deleteResponse.StatusCode);
            Console.WriteLine(deleteResponse.Content);
            return deleteResponse.Content;
        }

        public string GetResponseValue(string response, string key) 
        {
            var jObject = JObject.Parse(response);
            string value = jObject.GetValue(key).ToString();
            return value;
        }

    }
}
