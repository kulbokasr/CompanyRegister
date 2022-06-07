using CompanyRegister.Domain;
using CompanyRegister.Infrastucture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CompanyRegister.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.RegisterDomain();
            serviceCollection.RegisterDatabase(connectionString);
        }
    }
}
