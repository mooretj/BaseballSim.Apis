using BaseballSim.Apis.Services;
using BaseballSim.BLL.Services;
using BaseballSim.Core.Interfaces;
using BaseballSim.DAL;
using BaseballSim.DAL.Repos;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.Apis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<BaseballSimDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<IBatterRepository, BattersRepo>();
            builder.Services.AddTransient<BattersService>();
            builder.Services.AddTransient<IPitcherRepository, PitchersRepo>();
            builder.Services.AddTransient<PitchersService>();
            builder.Services.AddTransient<ITeamRepository, TeamsRepo>();
            builder.Services.AddTransient<TeamsService>();
            builder.Services.AddTransient<IGameRepository, GamesRepo>();
            builder.Services.AddTransient<GamesService>();
            builder.Services.AddCors(opt => opt.AddPolicy("Corspolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();
            
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("Corspolicy");
            app.UseHttpsRedirection();
            app.MapGrpcService<TeamsGrpcService>();
            app.MapGrpcService<GamesGrpcService>();
            app.MapGrpcService<PitchersGrpcService>();
            app.MapGrpcService<BattersGrpcService>();
            app.Run();
        }
    }
}

