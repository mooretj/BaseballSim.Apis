using BaseballSim.Core.Models;
using BaseballSim.Protos;

namespace BaseballSim.Core.Interfaces;

/// <summary>
/// Represents a service for managing <see cref="Batter"/>
/// </summary>
public interface IBattersService
{
    /// <summary>
    /// Retrieves a list of all <see cref="Batter"/>
    /// </summary>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A list of <see cref="Batter"/></returns>
    Task<List<Batter>> GetAllBattersAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a list of <see cref="Batter"/> by <see cref="Team"/> ID
    /// </summary>
    /// <param name="teamId">The unique ID of the <see cref="Team"/> for which <see cref="Batter"/> should be retrieved</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns></returns>
    Task<List<Batter>> GetBattersByTeamIdAsync(int teamId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a list of <see cref="Batter"/> by their name
    /// </summary>
    /// <param name="name">The name of the <see cref="Batter"/> to retrieve</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A list of <see cref="Batter"/></returns>
    Task<List<Batter>> GetBattersByNameAsync(string name, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a <see cref="Batter"/> by its ID
    /// </summary>
    /// <param name="batterId">The unique ID of the <see cref="Batter"/> to retrieve</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A single <see cref="Batter"/></returns>
    Task<Batter> GetBatterByIdAsync(int batterId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Creates a new <see cref="Batter"/>
    /// </summary>
    /// <param name="batter">The <see cref="Batter"/> to be created</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns></returns>
    Task<EmptyBatterResponse> CreateBatterAsync(Batter batter, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an existing <see cref="Batter"/>
    /// </summary>
    /// <param name="batter">The <see cref="Batter"/> to be updated</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns></returns>
    Task<EmptyBatterResponse> UpdateBatterAsync(Batter batter, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes an existing <see cref="Batter"/>
    /// </summary>
    /// <param name="batterId">The unique ID of the <see cref="Batter"/> to be deleted</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns></returns>
    Task<EmptyBatterResponse> DeleteBatterAsync(int batterId, CancellationToken cancellationToken = default);
}
