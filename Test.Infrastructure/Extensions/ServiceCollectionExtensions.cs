using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Abstractions;
using Test.Infrastructure.Persistence;

namespace Test.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomerfrastructure(this IServiceCollection services, IConfiguration config, string connectionStringName)
        {
            var connectionString = config.GetConnectionString(connectionStringName);

            services.AddMSSQL(connectionString);
            services.AddScoped<ICustomerDBContext>(provider => provider.GetService<CustomerDBContext>());
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(ICustomerRepository), typeof(CustomerRepository));

            return services;
        }

        private static IServiceCollection AddMSSQL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CustomerDBContext>(options =>
                       options.UseSqlServer(connectionString,
                       b => b.MigrationsAssembly(typeof(CustomerDBContext).Assembly.FullName)));
            //using var scope = services.BuildServiceProvider().CreateScope();
            //var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
            //dbContext.Database.Migrate();
            return services;
        }
    }
}
