using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;
using Grpc.Core;

namespace BaseballSim.Apis.Services;

public class TeamsGrpcService(ITeamsService teamsService)
{
    // public override async Task<IEnumerable<Team>> GetAllTeams(GetAllTeamsRequest request, ServerCallContext context)
    // {
    //     var teams = await teamsService.GetAllTeams(context.CancellationToken);
    //     return teams;
    // }
}
