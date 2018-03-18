using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopping.Api.Common;
using Shopping.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Shopping.Api.Domain.ServiceClients
{
    public interface IProductsClient
    {
        List<Product> Get();
    }

    public class ProductsClient : IProductsClient
    {
        private Settings _settings;
        public ProductsClient(IOptions<Settings> options)
        {
            _settings = options.Value;
        }
        public List<Product> Get()
        {
            try
            {
                var httpClient = new HttpClient();
                var url = $"{_settings?.ChallengeApi?.BaseUrl}/{_settings?.ChallengeApi?.ProductsEndpoint}?token={_settings.Token}";
            var data = httpClient.GetAsync(url);
                var result = data.Result?.Content?.ReadAsStringAsync()?.Result;

                var products = JsonConvert.DeserializeObject<List<Product>>(result);

                return products;
            }
            catch (Exception ex)
            {
                //Todo:Logging
                //Todo: proper exception propagation and reporting

                throw new Exception("Failed to get products from products resource", ex);
            }
           
        }
    }
}
