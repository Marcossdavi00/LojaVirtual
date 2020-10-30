using Domain.Interfaces.Repository;
using Infra.Context;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjections
{
    public class ConfigureInfra
    {
        public static void ConfigureDependenciesInfra(IServiceCollection service)
        {
            service.AddTransient<IRepositoryProducts, RepositoryProduct>();

            service.AddDbContext<MyContext>(options =>
                options.UseMySql("Server=localhost;Port=3306;Database=dbLojaVirtual;Uid=root;Pwd=123456")
            );
        }
    }
}
