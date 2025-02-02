using BaseballSim.Core.Models;
using BaseballSim.Protos;
using Microsoft.EntityFrameworkCore;


namespace BaseballSim.Core.Interfaces;
/// <summary>
/// The Interface defining methods for managing teams data within the database
/// </summary>
public interface ITeamRepository
{
    /// <summary>
    /// Add a <see cref="Team"/> to the database
    /// </summary>
    /// <param name="team">The team to be created</param>
    /// <param name="cancellationToken">A token to observe while waiting for task to complete. Default is none</param>
    /// <exception cref="DbUpdateException">An entity with the same ID already exists in the database</exception>
    Task<Team> CreateTeamAsync(Team team, CancellationToken cancellationToken = default);
    /// <summary>
    /// Retrieves a collection of <see cref="Team"/> entities from the database
    /// </summary>
    /// <param name="cancellationToken">A token to observe while waiting for task to complete. Default is none</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="Team"/> entities</returns>
    Task<List<Team>> ReadAllAsync(CancellationToken cancellationToken = default);
    /// <summary>
    /// Retrieves a single <see cref="Team"/> entity from the database
    /// </summary>
    /// <param name="id">The ID of the Team requested</param>
    /// <param name="cancellationToken">A token to observe while waiting for task to complete. Default is none</param>
    /// <exception cref="InvalidOperationException">Thrown when the Team does not exist in the database</exception>
    /// <returns>A task that represents the asynchronous operation. The task result contains a single <see cref="Team"/> entity</returns>
    Task<Team> ReadByIdAsync(int id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates the value of a single <see cref="Team"/> in the database
    /// </summary>
    /// <param name="team">The Team object to be updated</param>
    /// <param name="cancellationToken">A token to observe while waiting for task to complete. Default is none</param>
    /// <exception cref="InvalidOperationException">Thrown when the Team does not exist in the database</exception>
    Task UpdateTeamAsync(Team team, CancellationToken cancellationToken = default);
    /// <summary>
    /// Removes an existing <see cref="Team"/> from the database
    /// </summary>
    /// <param name="id">The ID of the Team to be deleted from the database</param>
    /// <param name="cancellationToken">A token to observe while waiting for task to complete. Default is none</param>
    /// <exception cref="InvalidOperationException">Thrown when the Team does not exist in the database</exception>
    Task DeleteTeamAsync(int id, CancellationToken cancellationToken = default);
}
