using Shopping.Api.Domain.ServiceClients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Api.Domain.Models
{
    public class TrolleyCalculator
    {
        private readonly ITrolleyCalculatorClient _trolleyCalculatorClient;

        public TrolleyCalculator(List<Product> products, List<Specials> specials,
            ITrolleyCalculatorClient trolleyCalculatorClient)
        {
            Products = products;
            Specials = specials;
            this._trolleyCalculatorClient = trolleyCalculatorClient;
        }

        public List<Product> Products { get; set; }
        public List<Specials> Specials { get; set; }
     
        public decimal LowestTotal(List<ProductQuantity> quantities)
        {
            return _trolleyCalculatorClient.LowestTotal(Products, Specials, quantities);
        }

    }
}
