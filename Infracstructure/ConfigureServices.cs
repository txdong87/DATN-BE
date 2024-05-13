
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.addscoped<auditableentitysavechangesinterceptor>();

        //services.adddbcontext<efcontext>(
        //    options => options.usesqlserver(configuration.getconnectionstring(settings.dbconnectionstringname),
        //    builder => builder.migrationsassembly(typeof(efcontext).assembly.fullname)));
        services.AddEntityFrameworkMySQL().AddDbContext<datnContext>(options => {
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
        });

        //services.AddScoped<IEfContext>(provider => provider.GetRequiredService<EfContext>());

        //services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
        //    .AddScoped<IUserRepository, UserRepository>()
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