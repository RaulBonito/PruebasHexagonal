using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PruebasHexagonal.Application.Communication.V1.Requests;
using PruebasHexagonal.Application.Communication.V1.Responses;
using PruebasHexagonal.Application.Handlers;
using PruebasHexagonal.Application.Services.Users;
using PruebasHexagonal.Application.UseCases.V1;
using PruebasHexagonal.Domain.Abstractions.Handlers;
using PruebasHexagonal.Domain.Abstractions.Presenters;
using PruebasHexagonal.Domain.Abstractions.Repositories;
using PruebasHexagonal.Domain.Abstractions.Services.Users;
using PruebasHexagonal.Domain.Abstractions.UseCases;
using PruebasHexagonal.Domain.Core.Responses;
using PruebasHexagonal.Infrastructure.Mapping.V1;
using PruebasHexagonal.Infrastructure.Presenters.V1;
using PruebasHexagonal.Infrastructure.Repositories;
using PruebasHexagonal.Infrastructure.Validators.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHexagonal.Infrastructure.IoC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserGetService, UserGetService>();
            return services;
        }

        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddSingleton<IPresenter<UserGetResponse>, UserGetPresenter>();
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IHandler<UserGetRequest, UserGetResponse>, UserGetHandler>();
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCase<UserGetRequest, AppResponse<UserGetResponse>>, UserGetUseCase>();
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserGetRequest>, UserGetValidator>(); 
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(V1Profile));
            return services;
        }
    }
}
