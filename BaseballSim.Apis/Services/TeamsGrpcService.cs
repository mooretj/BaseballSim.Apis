using BaseballSim.Common;
using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;
using Grpc.Core;

namespace BaseballSim.Apis.Services;

/// <inheritdoc/>
public class TeamsGrpcService(ITeamsService teamsService) : TeamsGrpc.TeamsGrpcBase
{
    /// <inheritdoc/>
    public override async Task<MultipleTeamDetail> GetAllTeams(GetAllTeamsRequest request, ServerCallContext context)
    {
        var teams = await teamsService.GetAllTeams(context.CancellationToken);
        var response = new MultipleTeamDetail();
        response.Teams.AddRange(teams.Select(t => t.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc/>
    public override async Task<TeamDetail> GetTeamById(GetTeamByIdRequest request, ServerCallContext context)
    {
        var team = await teamsService.GetTeamById(request.TeamId, context.CancellationToken);
        return team.ToDetail();
    }

    // /// <inheritdoc/>
    // public override async Task<EmptyResponse> CreateTeam(CreateTeamRequest request, ServerCallContext context)
    // {
    //     var teamToAdd = request.NewTeam;
    //     var result = await teamsService.CreateTeam(request.NewTeam, context.CancellationToken);
    // }

    // /// <inheritdoc/>
    // public override async Task<EmptyResponse> UpdateTeamAsync(Team team, ServerCallContext context)
    // {
    //      await teamsService.UpdateTeam(team, context.CancellationToken);
    //      return new EmptyResponse();
    // }
    //
    // /// <inheritdoc/>
    // public override async Task<EmptyResponse> DeleteTeamAsync(int id, ServerCallContext context)
    // {
    //     var response = new EmptyResponse();
    //     await teamsService.DeleteTeam(id, context.CancellationToken);
    //     return response;
    // }
}
