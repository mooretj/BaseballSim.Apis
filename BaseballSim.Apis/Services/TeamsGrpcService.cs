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

    /// <inheritdoc/>
    public override async Task<EmptyResponse> CreateTeam(CreateTeamRequest request, ServerCallContext context)
    {
        var teamToAdd = new Team(request.NewTeam);
        var result = await teamsService.CreateTeam(teamToAdd, context.CancellationToken);
        return new EmptyResponse();
    }

    /// <inheritdoc/>
    public override async Task<EmptyResponse> UpdateTeam(UpdateTeamByIdRequest request, ServerCallContext context)
    {
        var teamToUpdate = await teamsService.GetTeamById(request.TeamId, context.CancellationToken);
         await teamsService.UpdateTeam(teamToUpdate, context.CancellationToken);
         return new EmptyResponse();
    }
    
    /// <inheritdoc/>
    public override async Task<EmptyResponse> DeleteTeam(DeleteTeamByIdRequest request, ServerCallContext context)
    {
        var response = new EmptyResponse();
        await teamsService.DeleteTeam(request.TeamId, context.CancellationToken);
        return response;
    }
}
