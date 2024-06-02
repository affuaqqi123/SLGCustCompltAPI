using SLG.Application.Services.Interfaces;
using SLG.Domain.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLG.Domain.Entities;
using System.Data;
using SLG.Infrastructure;
using SLG.Domain.Repositories.Interfaces;
using System.Reflection;
using SLG.Shared.DTOs;
using FluentValidation;
using MediatR;
using SLG.Application.Behaviors;
using Blog.Application.Services.Interfaces;
using SLG.Infrastructure.Services;
using System.Data.SqlClient;
using SLG.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SLG.Infrastructure.Repositories;


namespace SLG.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
              configuration.GetConnectionString("SLGComplaintConnectionString") ??
              throw new ArgumentNullException(nameof(configuration));
            services.AddTransient<IUnitOfWork, DapperUnitOfWork>(c => new DapperUnitOfWork(connectionString));
            services.AddSingleton(new DefaultSqlConnectionFactory(connectionString));

            services.AddScoped<IFileUploadingService, FileUploadingService>();

            services.AddTransient<IGenericInterface, CustomerComplaintRespository>();

            services.AddTransient<IUsersInterface, UsersRepository>();
            services.AddTransient<IStoreLocationRepository, StoreLocationRepository>();
            
            services.AddTransient<IComplaintCategoryRepository, ComplaintCategoryRepository>();

            return services;
        }
    }
}
