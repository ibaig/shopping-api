using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopping.Api.Common;
using Shopping.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Api.Domain.ServiceClients
{
    public interface IShopperHistoryClient
    {
        Task<List<ShopperHistory>> Get();
    }

    public class ShopperHistoryClient : IShopperHistoryClient
    {
        private Settings _settings;
        public ShopperHistoryClient(IOptions<Settings> options)
        {
            _settings = options.Value;
        }
        public async Task<List<ShopperHistory>> Get()
        {
            try
            {
                var httpClient = new HttpClient();
                var url = $"{_settings?.ChallengeApi?.BaseUrl}/{_settings?.ChallengeApi?.ShopperHistoryEndpoint}?token={_settings.Token}";
                var data = await httpClient.GetAsync(url);
                var result = await data?.Content?.ReadAsStringAsync();

                var ShopperHistorys = JsonConvert.DeserializeObject<List<ShopperHistory>>(result);

                return ShopperHistorys;
            }
            catch (Exception ex)
            {
                //Todo:Logging
                //Todo: proper exception propagation and reporting

                throw new Exception("Failed to get ShopperHistory from ShopperHistory resource", ex);
            }

        }
    }
}
