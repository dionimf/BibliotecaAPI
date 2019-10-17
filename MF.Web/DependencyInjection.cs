using MF.Application.Services.User;
using MF.Domain.Interfaces;
using MF.Infra.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace MF.Web
{
    public static class DependencyInjection
    {
        public static void AddIoc(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}