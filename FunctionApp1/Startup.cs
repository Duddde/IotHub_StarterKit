using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API;
using API.Services;
using FunctionApp;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]

namespace FunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.AddHttpClient("client", c =>
            {
                c.BaseAddress = new Uri("https://iothub-api.azurewebsites.net");
            })
            .AddTypedClient(c => Refit.RestService.For<IDeviceService>(c));
        }
    }
}
