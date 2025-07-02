using CHL.Application.Abstractions;
using CHL.Application.Services;
using CHL.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CHL.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IClubService, ClubService>();
        service.AddScoped<ICoachService, CoachService>();
        service.AddScoped<IGameService, GameService>();
        service.AddScoped<INewsService, NewsService>();
        service.AddScoped<IPlayerService, PlayerService>();
        service.AddScoped<IRefereeService, RefereeService>();
        service.AddScoped<ISceneService, SceneService>();
        service.AddScoped<IStadiumService, StadiumService>();
        service.AddScoped<ITeamService, TeamService>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IJWTService, JWTService>();

        return service;
    }
}