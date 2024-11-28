using BaseballSim.Core.Interfaces;
using BaseballSim.Protos;

namespace BaseballSim.Apis.Services;

/// <inheritdoc/>
public class GamesGrpcService(IGamesService gamesService) : GamesGrpc.GamesGrpcBase
{
    
}
