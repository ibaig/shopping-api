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
    public interface ITrolleyCalculatorClient
    {
        decimal LowestTotal(List<Product> products, List<Specials> specials,
            List<ProductQuantity> quantities);
    }

    public class TrolleyCalculatorClient : ITrolleyCalculatorClient
    {
        private Settings _settings;
        public TrolleyCalculatorClient(IOptions<Settings> options)
        {
            _settings = options.Value;
        }
        public decimal LowestTotal(List<Product> products, List<Specials> specials,
            List<ProductQuantity> quantities)
        {
            try
            {
                var httpClient = new HttpClient();
                var url = $"{_settings?.ChallengeApi?.BaseUrl}/{_settings?.ChallengeApi?.TrolleyCalculatorsEndpoint}?token={_settings.Token}";
                var jsonObject = JsonConvert.SerializeObject(new
                {
                    Products = products,
                    Specials = specials,
                    Quantities = quantities
                });

                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                var data = httpClient.PostAsync(url, content);
                var result = data.Result?.Content?.ReadAsStringAsync()?.Result;

                return Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                //Todo:Logging
                //Todo: proper exception propagation and reporting

                throw new Exception("Failed to get TrolleyCalculator from TrolleyCalculator resource", ex);
            }

        }
    }
}
