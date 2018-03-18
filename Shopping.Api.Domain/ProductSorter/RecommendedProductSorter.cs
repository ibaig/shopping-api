using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using Shopping.Api.Domain.ServiceClients;
using System.Threading.Tasks;

namespace Shopping.Api.Domain.ProductSorter
{
    public class RecommendedProductSorter : IProductSorter
    {
        private readonly IShopperHistoryClient _shopperHistoryClient;

        public RecommendedProductSorter(IShopperHistoryClient shopperHistoryClient)
        {
            this._shopperHistoryClient = shopperHistoryClient;
        }
        public ProductSorterType Type => ProductSorterType.Recommended;

        public async Task<List<Product>> Sort(IEnumerable<Product> products)
        {
            var shopperHistory = await _shopperHistoryClient.Get();
            //extract products out
            var shopperHistoryProducts = shopperHistory.SelectMany(sh => sh.Products);

            //Aggregate product quantities
            var boughtQuantities = from sh in shopperHistoryProducts
                                   group sh by sh.Name into g
                                   select new
                                   {
                                       Name = g.Key,
                                       Quantity = g.ToList().Sum(p => p.Quantity)
                                   };

            var productsWithScore = products.Select(p =>
            {
                var bq = boughtQuantities.FirstOrDefault(b => b.Name == p.Name)?.Quantity;
                return new
                {
                    Product = p,
                    QuantityBought = bq != null ? bq.Value : 0
                };
            });

            var sorted = productsWithScore.OrderByDescending(p => p.QuantityBought).Select(p => p.Product).ToList();

            return sorted;
        }
    }
}
