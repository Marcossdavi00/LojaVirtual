using Domain.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Service;

namespace CrossCutting.DependencyInjections
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection service)
        {
            service.AddTransient<IServiceProduct, ServiceProducts>();
            service.AddTransient<IServiceSale, ServiceSale>();

        }
    }
}
