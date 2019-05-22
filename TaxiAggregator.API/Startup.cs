using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiAggregator.API.Mappers;
using TaxiAggregator.Bolt;
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

            // var http = new HttpClient();

            services.AddTransient<IUberClient>(
                x => new UberHttpClient(new HttpClient(), "G2BVdH1STnzYM75I3OVsp5XdYMSQipE0RNcvHxcV"));
            services.AddTransient<IUklonClient>(x => new UklonHttpClient(new HttpClient(),
                "f42222a32583453089a77af021bca83cn",
                "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhMzg0IiwidHlwIjoiSldUIn0.eyJqdGkiOiI0MjhiN2I3MDM1YzQ0NTY4ODVhN2YzMWE2YjYyNjQ3ZiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvZ3JvdXBzaWQiOiJNeER2WlNLN3ZWeU4zMEM5YTV5N1ZZMm4yT3N2bnNMN2VKUGtIVENDX2p3RW12b3h0RktmdFpkWkpaZDJuZGVrIiwidW5pcXVlX25hbWUiOiJvbGVnLmR5c3Rha0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoib2xlZy5keXN0YWtAZ21haWwuY29tIiwibmFtZWlkIjoiYWI1OGM0ZmItNGY5MC00NjgyLWIyYWMtMDkxZTdjMWUwNjU2IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiJhYjU4YzRmYi00ZjkwLTQ2ODItYjJhYy0wOTFlN2MxZTA2NTYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJvbGVnLmR5c3Rha0BnbWFpbC5jb20iLCJlbWFpbCI6Im9sZWcuZHlzdGFrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2xvY2FsaXR5IjoiNSIsIm5iZiI6MTU1ODUzMTg4NywiZXhwIjoxNTU4NTQ2Mjg3LCJpYXQiOjE1NTg1MzE4ODcsImlzcyI6Imh0dHBzOi8vdWtsb24uY29tLnVhLyIsImF1ZCI6Imh0dHBzOi8vdWtsb24uY29tLnVhLyIsInByb3BlcnRpZXMiOnsiYXBwX3VpZCI6IjAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwIiwiY2xpZW50X2lkIjoiZjQyMjIyYTMyNTgzNDUzMDg5YTc3YWYwMjFiY2E4M2NuIn19.rogDZEDu4SkwbarBgBjS9NLWNmrqpOv2BiJYDVBGmhwBXmUmeN760mMsgoNqljaLg8FsJHtnlWRKdAvLZjgt1cYdaNOmlJ8Mzo13f2zVMiiZz4kd_Zp-5Jkuzd1BNqKl5kZekOxnjN_ckCQ7nu3RqJCAhhQxNbv7_BJlDsfBWRpxrH-HU8aUS9cd6Xeq3B_d4oygvKgrVYlar4pUUI24FVn3m72f1neR5MP8KneMT4kgBiLfkq6HV20DfN18mNZHdm67BPMKmBiJEP3VeXmEt97CjcDTq_iQba9tKCh_m9y-v0aI8koeJifSrRnnQm141HN95fmRvt-w5IKbgkxAAw"));
            services.AddTransient<IBoltClient>(x =>
                new BoltHttpClient(new HttpClient(),
                    "KzM4MDYzOTI5NjUzNzphZGZkMjE0Yi01ZjA4LTM0NGQtYTM2Ni0yODBmMTZlMjUwMWQ="));
            services.AddTransient<ITaxi838Client>(x => new Taxi838HttpClient(new HttpClient()));
        }
    }
}