﻿using Application.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<INurseService, NurseService>();
        services.AddScoped<IKTVService, KTVService>();
        services.AddScoped<ICaseStudyService, CaseStudyService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}