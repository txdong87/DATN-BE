using Domain.Interfaces;
using Domain.IRepository;
using Infracstructure.Persistance;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:Secret"]);

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

        services.AddEntityFrameworkMySql().AddDbContext<datnContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IBaseRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IAuthRepository, AuthRepository>(provider =>
        {
            var dbContext = provider.GetRequiredService<datnContext>();
            var secretKey = configuration["JwtSettings:Secret"];
            return new AuthRepository(dbContext, secretKey);
        });
        services.AddScoped<IPatientRepository, PatientRepository>()
                .AddScoped<IDoctorRepository, DoctorRepository>()
                .AddScoped<INurseRepository, NurseRepository>()
                .AddScoped<IKTVRepository, KTVRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ICaseStudyRepository, CaseStudyRepository>();

        return services;
    }
}
