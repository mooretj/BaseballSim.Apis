using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;
using Grpc.Core;

namespace BaseballSim.Apis.Services;

/// <inheritdoc />
public class BattersGrpcService(IBattersService battersService) : BattersGrpc.BattersGrpcBase
{
    /// <inheritdoc />
    public override async Task<MultipleBatterDetail> GetAllBatters(GetAllBattersRequest request, ServerCallContext context)
    {
        var batters = await battersService.GetAllBattersAsync(context.CancellationToken);
        var response = new MultipleBatterDetail();
        response.Batters.AddRange(batters.Select(b => b.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc />
    public override async Task<MultipleBatterDetail> GetBattersByName(GetBattersByNameRequest request,
        ServerCallContext context)
    {
        var batters = await battersService.GetBattersByNameAsync(request.SearchTerm, context.CancellationToken);
        var response = new MultipleBatterDetail();
        response.Batters.AddRange(batters.Select(b => b.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc />
    public override async Task<MultipleBatterDetail> GetBattersByTeamId(GetBatterByTeamIdRequest request,
        ServerCallContext context)
    {
        var batters = await battersService.GetBattersByTeamIdAsync(request.TeamId, context.CancellationToken);
        var response = new MultipleBatterDetail();
        response.Batters.AddRange(batters.Select(b => b.ToDetail()).ToArray());
        return response;
    }

    /// <inheritdoc />
    public override async Task<BatterDetail> GetBatterById(GetBatterByIdRequest request, ServerCallContext context)
    {
        var batter = await battersService.GetBatterByIdAsync(request.BatterId, context.CancellationToken);
        return batter.ToDetail();
    }

    /// <inheritdoc />
    public override async Task<EmptyBatterResponse> CreateBatter(CreateBatterRequest request, ServerCallContext context)
    {
        var batterToAdd = new Batter(request.Batter);
        await battersService.CreateBatterAsync(batterToAdd, context.CancellationToken);
        return new EmptyBatterResponse();
    }

    /// <inheritdoc />
    public override async Task<EmptyBatterResponse> UpdateBatter(UpdateBatterByIdRequest request,
        ServerCallContext context)
    {
        var batterToUpdate = new Batter(request.UpdatedBatter);
        await battersService.UpdateBatterAsync(batterToUpdate, context.CancellationToken);
        return new EmptyBatterResponse();
    }

    /// <inheritdoc />
    public override async Task<EmptyBatterResponse> DeleteBatter(DeleteBatterByIdRequest request,
        ServerCallContext context)
    {
        await battersService.DeleteBatterAsync(request.BatterId, context.CancellationToken);
        return new EmptyBatterResponse();
    }
}
