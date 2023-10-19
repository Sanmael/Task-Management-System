using Application.Interfaces;
using Application.Services;
using Domain.DomainServices;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MockDataAccess.Tests.BaseRepository;
using MockDataAccess.Tests.Repositories;

namespace Infrastructure
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services)
        {
            services = AddServices(services);
            services = AddRepositories(services);

            return services;
        }
        public static IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserValidation, UserValidation>();
            return services;
        }
        public static IServiceCollection AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseMockRepository>();
            services.AddSingleton<MockEntityRepository>();
            services.AddScoped<IUserRepository, MockUserRepository>();
            services.AddScoped<IPersonRepository, MockPersonRepository>();

            return services;
        }
    }
}