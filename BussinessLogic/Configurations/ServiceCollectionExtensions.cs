using BussinessLogic.Abstractions;
using BussinessLogic.Implementations;
using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BussinessLogic.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<ILogic<User>, UserLogic>();
        }
    }
}