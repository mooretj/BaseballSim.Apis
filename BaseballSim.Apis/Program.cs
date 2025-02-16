using BaseballSim.Apis.Services;
using BaseballSim.BLL.Services;
using BaseballSim.Core.Interfaces;
using BaseballSim.DAL;
using BaseballSim.DAL.Repos;
using Microsoft.EntityFrameworkCore;


    var builder = WebApplication.CreateBuilder(args);
    
    builder.Configuration
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();
    
    builder.Services.AddGrpc().AddJsonTranscoding();
    builder.Services.AddControllers();
    builder.Services.AddDbContext<BaseballSimDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddTransient<IBatterRepository, BattersRepo>();
    builder.Services.AddTransient<IBattersService, BattersService>();
    builder.Services.AddTransient<IPitcherRepository, PitchersRepo>();
    builder.Services.AddTransient<IPitchersService, PitchersService>();
    builder.Services.AddTransient<ITeamRepository, TeamsRepo>();
    builder.Services.AddTransient<ITeamsService, TeamsService>();
    builder.Services.AddTransient<IGameRepository, GamesRepo>();
    builder.Services.AddTransient<IGamesService, GamesService>();
    builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:7240")));
    builder.Services.AddHealthChecks();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddGrpcReflection();
    
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    
    var app = builder.Build();
    
    if(app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseHsts();
    app.UseCors("CorsPolicy");
    app.UseHttpsRedirection();
    app.UseGrpcWeb();
    app.MapHealthChecks("/api/health");
    app.MapControllers();
    app.MapGrpcService<TeamsGrpcService>();
    app.MapGrpcService<GamesGrpcService>();
    app.MapGrpcService<PitchersGrpcService>();
    app.MapGrpcService<BattersGrpcService>();
    app.MapGrpcReflectionService();
    app.Run();
