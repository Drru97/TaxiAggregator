using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiAggregator.API.Mappers;
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

            services.AddDbContext<TaxiAggregatorContext>();

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
        }

        private static void RegisterTaxiDependencies(IServiceCollection services)
        {
            services.AddTransient<ITaxiService, LvivTaxiService>();

            services.AddSingleton<IOrderValidator, TaxiOrderValidator>();
            services.AddSingleton<IOrderMapper, TaxiOrderMapper>();
            services.AddSingleton<IRequestFactory, RequestFactory>();
            services.AddSingleton<ITaxiResponseMapper, TaxiResponseMapper>();
            services.AddSingleton<IDistanceProvider, GoogleMapsDistanceProvider>();

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
