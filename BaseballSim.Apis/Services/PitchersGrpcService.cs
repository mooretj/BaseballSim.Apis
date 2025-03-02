using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;
using Grpc.Core;

namespace BaseballSim.Apis.Services;

/// <inheritdoc />
public class PitchersGrpcService(IPitchersService pitchersService) : PitchersGrpc.PitchersGrpcBase
{
    /// <inheritdoc />
    public override async Task<MultiplePitcherDetail> GetAllPitchers(GetAllPitchersRequest request,
        ServerCallContext context)
    {
        var pitchers = await pitchersService.GetAllPitchersAsync(context.CancellationToken);
        var response = new MultiplePitcherDetail();
        response.Pitchers.AddRange(pitchers.Select(p => p.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc />
    public override async Task<MultiplePitcherDetail> GetPitchersByTeamId(GetPitchersByTeamIdRequest request, ServerCallContext context)
    {
        var pitchers = await pitchersService.GetAllPitchersByTeamIdAsync(request.TeamId, context.CancellationToken);
        var response = new MultiplePitcherDetail();
        response.Pitchers.AddRange(pitchers.Select(p => p.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc />
    public override async Task<MultiplePitcherDetail> GetPitchersByName(GetPitchersByNameRequest request, ServerCallContext context)
    {
        var pitchers = await pitchersService.GetAllPitchersByNameAsync(request.SearchTerm, context.CancellationToken);
        var response = new MultiplePitcherDetail();
        response.Pitchers.AddRange(pitchers.Select(p => p.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc />
    public override async Task<PitcherDetail> GetPitcherById(GetPitcherByIdRequest request, ServerCallContext context)
    {
        var pitcher = await pitchersService.GetPitcherByIdAsync(request.PitcherId, context.CancellationToken);
        return pitcher.ToDetail();
    }

    /// <inheritdoc />
    public override async Task<EmptyPitcherResponse> CreatePitcher(CreatePitcherRequest request,
        ServerCallContext context)
    {
        var pitcherToAdd = new Pitcher(request.Pitcher);
        await pitchersService.CreatePitcherAsync(pitcherToAdd, context.CancellationToken);
        return new EmptyPitcherResponse();
    }

    /// <inheritdoc />
    public override async Task<EmptyPitcherResponse> UpdatePitcher(UpdatePitcherByIdRequest request,
        ServerCallContext context)
    {
        var pitcherToUpdate = new Pitcher(request.UpdatedPitcher);
        await pitchersService.UpdatePitcherAsync(pitcherToUpdate, context.CancellationToken);
        return new EmptyPitcherResponse();
    }

    /// <inheritdoc />
    public override async Task<EmptyPitcherResponse> DeletePitcher(DeletePitcherByIdRequest request,
        ServerCallContext context)
    {
        await pitchersService.DeletePitcherAsync(request.PitcherId, context.CancellationToken);
        return new EmptyPitcherResponse();
    }
}
