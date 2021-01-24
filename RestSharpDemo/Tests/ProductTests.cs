using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpDemo.Entities;
using System;

namespace RestSharpDemo
{
    public class Tests
    {
        private string baseUrl;

        [SetUp]
        public void Setup()
        {
            this.baseUrl = "http://34.205.174.166/wp-json/wc/v3";
        }

        [Test]
        public void Test1()
        {
            
            string jsonData = "{\"name\":\"Premium Quality\",\"type\":\"simple\",\"regular_price\":\"21.99\",\"description\":\"Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo.\",\"short_description\":\"Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.\",\"categories\":[{\"id\":9},{\"id\":14}],\"images\":[{\"src\":\"http:\\/\\/demo.woothemes.com\\/woocommerce\\/wp-content\\/uploads\\/sites\\/56\\/2013\\/06\\/T_2_front.jpg\"},{\"src\":\"http:\\/\\/demo.woothemes.com\\/woocommerce\\/wp-content\\/uploads\\/sites\\/56\\/2013\\/06\\/T_2_back.jpg\"}]}";

            ProductRequests productRequest = new ProductRequests();
            string postResponse = productRequest.CreateProduct(baseUrl + "/products", jsonData);

            string id = productRequest.GetResponseValue(postResponse,"id");

            string deleteUrl = baseUrl + "/products/" + id + "?force=true";
            string deleteResponse = productRequest.DeleteProduct(deleteUrl); 
            
            
        }
    }
}