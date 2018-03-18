using System;

namespace Shopping.Api.Common
{
    public class Settings
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public ChallengeApiSettings ChallengeApi { get; set; }
    }


    public class ChallengeApiSettings
    {
        public string BaseUrl { get; set; }
        public string ProductsEndpoint { get; set; }
        public string TrolleyCalculatorsEndpoint { get; set; }
        public string ShopperHistoryEndpoint { get; set; }

    }
}
