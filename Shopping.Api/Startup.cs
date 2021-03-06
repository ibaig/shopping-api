﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shopping.Api.Common;
using Shopping.Api.Domain.ProductSorter;
using Shopping.Api.Domain.Repositories;
using Shopping.Api.Domain.ServiceClients;
using Shopping.Api.Domain.Services;
using Shopping.Api.Mappings;
using Swashbuckle.AspNetCore.Swagger;

namespace Shopping.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //AppSettings
            services.Configure<Settings>(options => Configuration.GetSection("Settings").Bind(options));

            //Adding Swagger Documentation
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new Info
            {
                Title = "Shopping API",
                Version = "v1"
            }));


            //Other registrations
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IProductsClient, ProductsClient>();
            services.AddSingleton<IShopperHistoryClient, ShopperHistoryClient>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ITrolleyCalculatorClient, TrolleyCalculatorClient>();


            services.AddSingleton<IProductSorter, LowPriceProductSorter>();
            services.AddSingleton<IProductSorter, HighPriceProductSorter>();
            services.AddSingleton<IProductSorter, NameAscendingProductSorter>();
            services.AddSingleton<IProductSorter, NameDescendingProductSorter>();
            services.AddSingleton<IProductSorter, RecommendedProductSorter>();


            //Automapper
            AutomapperMappings.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Adding Swagger middleware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping API"));

            app.UseMvc();
        }
    }
}
