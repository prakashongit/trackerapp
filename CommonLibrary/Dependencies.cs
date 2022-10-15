using CommonLibrary.BusinessLogic.Implementation;
using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.Repository.Implementation;
using CommonLibrary.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public static class Dependencies
    {
        public static IServiceCollection AddRepository(this IServiceCollection services) {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRightsRepository, RightsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<ITaskBusiness, TaskBusiness>();
            services.AddTransient<IProjectBusiness, ProjectBusiness>();

            //JWT service
            services.AddSingleton<JWTService>();
            return services;
        }
    }
}
