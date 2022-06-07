using CompanyRegister.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyRegister.Domain
{
    public static class DependencyInjection
    {
        public static void RegisterDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CompanyService>();
            serviceCollection.AddTransient<OwnerService>();
        }
    }
}
