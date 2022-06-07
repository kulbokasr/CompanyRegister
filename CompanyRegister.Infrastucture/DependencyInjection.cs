using CompanyRegister.Domain.Interfaces;
using CompanyRegister.Infrastucture.Data;
using CompanyRegister.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CompanyRegister.Infrastucture
{
    public static class DependencyInjection
    {
        public static void RegisterDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DataContext>(d => d.UseSqlServer(connectionString));
            serviceCollection.AddTransient<ICompanyRepository, CompanyRepository>();
            serviceCollection.AddTransient<IOwnerRepository, OwnerRepository>();
        }
    }
}
