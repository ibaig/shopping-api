﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping.Api.Domain.Models;
using Shopping.Api.Domain.ServiceClients;
using Shopping.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [Route("[controller]")]
    [Route("trolleyTotal")]
    public class TrolleyCalculatorController
    {
        private readonly ITrolleyCalculatorClient _trolleyCalculatorClient;

        public TrolleyCalculatorController(ITrolleyCalculatorClient trolleyCalculatorClient)
        {
            this._trolleyCalculatorClient = trolleyCalculatorClient;
        }


        // POST api/trolleryCalculator
        // POST api/trolleryTotal
        [HttpPost]
        public async Task<decimal> Post([FromBody]TrolleyDataDto trolleyData)
        {
            var quantities = Mapper.Map<List<ProductQuantity>>(trolleyData?.Quantities);

            var calculator = CreateTrolleyCalculator(trolleyData);

            return await calculator.LowestTotal(quantities);
        }



        private TrolleyCalculator CreateTrolleyCalculator(TrolleyDataDto trolleyData)
        {
            var products = Mapper.Map<List<Product>>(trolleyData?.Products);
            var specials = Mapper.Map<List<Specials>>(trolleyData?.Specials);

            return new TrolleyCalculator(products, specials, _trolleyCalculatorClient);
        }

    }
}
