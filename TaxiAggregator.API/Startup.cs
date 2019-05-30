using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TaxiAggregator.API.Mappers;
using TaxiAggregator.API.Validation;
using TaxiAggregator.Bolt;
using TaxiAggregator.DataAccess;
using TaxiAggregator.DataAccess.Generic;
using TaxiAggregator.Services;
using TaxiAggregator.Taxi838;
using TaxiAggregator.Uber;
using TaxiAggregator.Uklon;

namespace TaxiAggregator.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(s =>
            {
                var xmlDocumentationPath = $"{AppDomain.CurrentDomain.BaseDirectory}TaxiAggregator.API.xml";
                
                s.SwaggerDoc("v1", new Info
                {
                    Title = "Taxi Aggregator API",
                    Description = "Aggregator for Uber, Uklon, Bolt, Taxi 838 services.",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Email = "oleg.dystak@gmail.com",
                        Name = "Oleh Dutsiak"
                    }
                });
                s.IncludeXmlComments(xmlDocumentationPath);
            });

            RegisterTaxiDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Taxi Aggregator API"));
        }

        private static void RegisterTaxiDependencies(IServiceCollection services)
        {
            services.AddTransient<ITaxiService, LvivTaxiService>();

            services.AddSingleton<IOrderValidator, TaxiOrderValidator>();
            services.AddSingleton<IOrderMapper, TaxiOrderMapper>();
            services.AddSingleton<IRequestFactory, RequestFactory>();
            services.AddSingleton<ITaxiResponseMapper, TaxiResponseMapper>();
            services.AddSingleton<IDistanceProvider, GoogleMapsDistanceProvider>();

            services.AddSingleton<IRequestValidator, TaxiRequestValidator>();

            RegisterTaxiClients(services);
            RegisterDatabaseDependencies(services);
        }

        private static void RegisterTaxiClients(IServiceCollection services)
        {
            services.AddTransient<IUberClient>(x => new UberHttpClient(new HttpClient(), ServicesConstants.UBER_TOKEN));
            services.AddTransient<IUklonClient>(x => new UklonHttpClient(new HttpClient(),
                ServicesConstants.UKLON_CLIENT_ID, ServicesConstants.UKLON_TOKEN));
            services.AddTransient<IBoltClient>(x => new BoltHttpClient(new HttpClient(), ServicesConstants.BOLT_TOKEN));
            services.AddTransient<ITaxi838Client>(x => new Taxi838HttpClient(new HttpClient()));
        }

        private static void RegisterDatabaseDependencies(IServiceCollection services)
        {
            services.AddSingleton<IDbFactory<TaxiAggregatorContext>, DbFactory<TaxiAggregatorContext>>();
            services.AddTransient<IHistoricalDataRepository, HistoricalDataRepository>();
            services.AddTransient<IUnitOfWork<TaxiAggregatorContext>, UnitOfWork<TaxiAggregatorContext>>();
            services.AddTransient<IHistoricalDataService, HistoricalDataService>();
        }
    }
}
