
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Domain.IRepository;

namespace Infrastructure;
public static class ConfigureServices
{
    private static string secretKey="TXD";

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.addscoped<auditableentitysavechangesinterceptor>();
        {
            var key = Encoding.ASCII.GetBytes("TXĐ");
           
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //services.adddbcontext<efcontext>(
            //    options => options.usesqlserver(configuration.getconnectionstring(settings.dbconnectionstringname),
            //    builder => builder.migrationsassembly(typeof(efcontext).assembly.fullname)));
            services.AddEntityFrameworkMySQL().AddDbContext<datnContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
            });
        }
        //services.AddScoped<IEfContext>(provider => provider.GetRequiredService<EfContext>());

        services.AddScoped(typeof(IBaseRepository<>), typeof(RepositoryBase<>))
                .AddScoped<IAuthRepository, AuthRepository>(provider =>
           {
               var dbContext = provider.GetService<datnContext>();
               return new AuthRepository(dbContext, secretKey);
           });
        //    .AddScoped<IAssetRepository, AssetRepository>()
        //    .AddScoped<IAssignmentRepository, AssignmentRepository>()
        //    .AddScoped<ICategoryRepository, CategoryRepository>()
        //    .AddScoped<IRequestForReturningRepository, RequestForReturningRepository>();

        //services.AddScoped<IUnitOfWork, UnitOfWork>();

        //services.AddScoped<EfContextInitializer>();

        //services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}