using Shopping.Api.Domain.Models;
using Shopping.Api.Domain.ProductSorter;
using Shopping.Api.Domain.ServiceClients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Api.Domain.Services
{
    public interface IProductService
    {
        List<Product> Get(string sortOption);
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
        public List<Product> Get(string sortOption)
        {
            var products = _productsClient.Get();
            if (products == null) return null;

            _productSorters.

            return products;
        }
    }
}
