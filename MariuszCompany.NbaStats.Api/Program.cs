using MariuszCompany.NbaStats.Application.Interfaces;
using MariuszCompany.NbaStats.Application.Mappings;
using MariuszCompany.NbaStats.Infrastructure.DbContexts;
using MariuszCompany.NbaStats.Infrastructure.NbaApi;
using MariuszCompany.NbaStats.Infrastructure;
using MariuszCompany.NbaStats.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Infrastructure.Repositories;
using MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery;
using MariuszCompany.NbaStats.Application.Data;
using MariuszCompany.NbaStats.Infrastructure.SqlConnection;
using MariuszCompany.NbaStats.Application.PiplinesBehaviours;
using MediatR;
using FluentValidation;
using MariuszCompany.NbaStats.Application.Dto.NbaIntegration;
using MariuszCompany.NbaStats.Api.Middlewares;
using Serilog;
using System.Diagnostics;
namespace MariuszCompany.NbaStats.Api
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddValidatorsFromAssembly(typeof(GetPlayersByTeamIdHandler).Assembly);
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(GetPlayersByTeamIdHandler).Assembly);
            });
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddScoped<INbaApiClient, NbaApiClient>();
            builder.Services.AddScoped<IIntegrationService, IntegrationService>();
            builder.Services.AddScoped<IPlayersRepository, PlayersEfRepository>();
            builder.Services.AddScoped<ITeamsRepository, TeamsEfRepository>();
            builder.Services.AddScoped<IGamesRepository, GamesDapperRepository>();
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Host.UseSerilog((ctx, lc) => lc
                .ReadFrom.Configuration(ctx.Configuration));

            builder.Services.AddDbContext<NbaDbContext>(op => op.UseSqlServer(builder.Configuration["DbConnectionString"]));
            builder.Services.AddScoped<ISqlConnectionFactory>(provider =>
                new SqlConnectionFactory(builder.Configuration["DbConnectionString"])
            );


            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var dbContext = services.GetRequiredService<NbaDbContext>();
            await dbContext.Database.MigrateAsync();

            var integrator = services.GetRequiredService<IIntegrationService>();
            await integrator.Import();

            app.Run();
        }
    }
}
