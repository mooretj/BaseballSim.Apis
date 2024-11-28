using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;
using Grpc.Core;

namespace BaseballSim.Apis.Services;

/// <inheritdoc/>
public class GamesGrpcService(IGamesService gamesService) : GamesGrpc.GamesGrpcBase
{
    /// <inheritdoc/>
    public override async Task<MultipleGameDetail> GetAllGames(GetAllGamesRequest request, ServerCallContext context)
    {
        var games = await gamesService.GetAllGamesAsync(context.CancellationToken);
        var response = new MultipleGameDetail();
        response.Games.AddRange(games.Select(g => g.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc/>
    public override async Task<GameDetail> GetGameById(GetGameByIdRequest request, ServerCallContext context)
    {
        var game = await gamesService.GetGameByIdAsync(request.GameId, context.CancellationToken);
        return game.ToDetail();
    }

    /// <inheritdoc/>
    public override async Task<MultipleGameDetail> GetGamesByTeamId(GetGamesByTeamIdRequest request,
        ServerCallContext context)
    {
        var games = await gamesService.GetGamesByTeamIdAsync(request.TeamId, context.CancellationToken);
        var response = new MultipleGameDetail();
        response.Games.AddRange(games.Select(g => g.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc/>
    public override async Task<EmptyGameResponse> CreateGame(CreateGameRequest request, ServerCallContext context)
    {
        var gameToAdd = new Game(request.Game)
        {
            HomeTeamName = request.Game.HomeTeamName,
            AwayTeamName = request.Game.AwayTeamName,
        };
        await gamesService.CreateGameAsync(gameToAdd, context.CancellationToken);
        return new EmptyGameResponse();
    }

    /// <inheritdoc/>
    public override async Task<EmptyGameResponse> UpdateGameById(UpdateGameByIdRequest request, ServerCallContext context)
    {
        var gameToUpdate = await gamesService.GetGameByIdAsync(request.GameId, context.CancellationToken);
        await gamesService.UpdateGameAsync(gameToUpdate, context.CancellationToken);
        return new EmptyGameResponse();
    }

    /// <inheritdoc/>
    public override async Task<EmptyGameResponse> DeleteGame(DeleteGameByIdRequest request, ServerCallContext context)
    {
        await gamesService.DeleteGameAsync(request.GameId, context.CancellationToken);
        return new EmptyGameResponse();
    }
}
