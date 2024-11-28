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
        var teams = await teamsService.GetAllTeamsAsync(context.CancellationToken);
        var response = new MultipleTeamDetail();
        response.Teams.AddRange(teams.Select(t => t.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc/>
    public override async Task<TeamDetail> GetTeamById(GetTeamByIdRequest request, ServerCallContext context)
    {
        var team = await teamsService.GetTeamByIdAsync(request.TeamId, context.CancellationToken);
        return team.ToDetail();
    }

    /// <inheritdoc/>
    public override async Task<EmptyTeamResponse> CreateTeam(CreateTeamRequest request, ServerCallContext context)
    {
        var teamToAdd = new Team(request.NewTeam);
        var result = await teamsService.CreateTeamAsync(teamToAdd, context.CancellationToken);
        return new EmptyTeamResponse();
    }

    /// <inheritdoc/>
    public override async Task<EmptyTeamResponse> UpdateTeam(UpdateTeamByIdRequest request, ServerCallContext context)
    {
        var teamToUpdate = await teamsService.GetTeamByIdAsync(request.TeamId, context.CancellationToken);
         await teamsService.UpdateTeamAsync(teamToUpdate, context.CancellationToken);
         return new EmptyTeamResponse();
    }
    
    /// <inheritdoc/>
    public override async Task<EmptyTeamResponse> DeleteTeam(DeleteTeamByIdRequest request, ServerCallContext context)
    {
        await teamsService.DeleteTeamAsync(request.TeamId, context.CancellationToken);
        return new EmptyTeamResponse();
    }
}
