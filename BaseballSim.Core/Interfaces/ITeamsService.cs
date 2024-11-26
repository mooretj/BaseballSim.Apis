using BaseballSim.Core.Models;

namespace BaseballSim.Core.Interfaces;

/// <summary>
/// Represents a service for managing Teams
/// </summary>
public interface ITeamsService
{
    /// <summary>
    /// Retrieves a list of all Teams
    /// </summary>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns></returns>
    Task<IEnumerable<Team>> GetAllTeams(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a single Team by its ID
    /// </summary>
    /// <param name="id">Unique ID of the Team to retrieve</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns></returns>
    Task<Team> GetTeamById(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Creates a new Team
    /// </summary>
    /// <param name="team">The Team to create</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns></returns>
    Task<Team> CreateTeam(Team team, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an existing Team
    /// </summary>
    /// <param name="team">The Team to be updated</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns></returns>
    Task<Team> UpdateTeam(Team team, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes an existing Team
    /// </summary>
    /// <param name="id">The unique ID of the Team to be deleted</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns></returns>
    Task DeleteTeam(int id, CancellationToken cancellationToken = default);
}
