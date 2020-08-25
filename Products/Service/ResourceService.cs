using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Products.Service
{
    public class ResourceService : IResoureService
    {
        private readonly string _baseAddress;

        private readonly string _token;
        public ResourceService()
        {
            _baseAddress = "http://dev-wooliesx-recruitment.azurewebsites.net/api/";
            _token = "3fb12a33-3dd0-4d7e-87c1-194d9b34b871";
        }
        public List<Models.Products> GetProducts()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"resource/products/?token={_token}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask = result.Content.ReadAsAsync<List<Models.Products>>();
                readTask.Wait();

                return readTask.Result;

            }
        }

        public List<Models.Customer> GetShopperHistory()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"resource/shopperHistory/?token={_token}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask = result.Content.ReadAsAsync<List<Models.Customer>>();
                readTask.Wait();

                return readTask.Result;

            }
        }
    }
}