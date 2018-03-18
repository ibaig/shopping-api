using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping.Api.Domain.Services;
using Shopping.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    public class SortController
    {
        private readonly IProductService _productService;

        public SortController(IProductService productService )
        {
            this._productService = productService;
        }

        // GET api/sort
        [HttpGet]
        public List<ProductDto> Sort(string sortOption)
        {
            var products  = _productService.Get(sortOption);

            var productDtos = Mapper.Map<List<ProductDto>>(products);

            return productDtos;
        }
    }
}
