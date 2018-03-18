using Shopping.Api.Domain.Models;
using Shopping.Api.Domain.ProductSorter;
using Shopping.Api.Domain.ServiceClients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Domain.Services
{
    /// <summary>
    /// Provides functionality to Work with products
    /// </summary>
    public interface IProductService
    {
        Task<List<Product>> Get(string sortOption);
    }

   
    public class ProductService : IProductService
    {
        private readonly IProductsClient _productsClient;
        private readonly IEnumerable<IProductSorter> _productSorters;

        public ProductService(IProductsClient productsClient, IEnumerable<IProductSorter> productSorters)
        {
            this._productsClient = productsClient;
            this._productSorters = productSorters;
        }
        public async Task<List<Product>> Get(string sortOption)
        {
            var products = await _productsClient.Get();
            if (products == null) return null;

            var sorter = GetSorter(sortOption);

            return sorter.Sort(products);
        }


        /// <summary>
        /// Get the right sorted based on the sortOption
        /// </summary>
        /// <param name="sortOption">the sortOption. If not supplied or is incorrect value, default will be low</param>
        /// <returns></returns>
        private IProductSorter GetSorter(string sortOption)
        {
            ProductSorterType sorterType;

            //default
            if (!Enum.TryParse(sortOption,true, out sorterType))
                sorterType = ProductSorterType.Low;

            return _productSorters.FirstOrDefault(s => s.Type == sorterType);

        }
    }
}
