using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.Core.Interfaces;

/// <summary>
/// The Interface defining methods for managing <see cref="Pitcher"/> data within the database
/// </summary>
public interface IPitcherRepository
{
    /// <summary>
    /// Add a <see cref="Pitcher"/> to the database
    /// </summary>
    /// <param name="pitcher">The <see cref="Pitcher"/> to be created</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <exception cref="DbUpdateException">An entity with the same ID already exists in the database</exception>
    Task<Pitcher> CreatePitcherAsync(Pitcher pitcher, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a collection of <see cref="Pitcher"/> entities from the database
    /// </summary>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A task that represents the asynchronous operation. The result contains a collection of <see cref="Pitcher"/> entities</returns>
    Task<List<Pitcher>> ReadAllPitchersAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a single <see cref="Pitcher"/> entity from the database
    /// </summary>
    /// <param name="id">The unique ID of the <see cref="Pitcher"/> requested</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A task that represents the asynchronous operation. The result contains a <see cref="Pitcher"/> entity</returns>
    Task<Pitcher> ReadPitcherByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a collection of <see cref="Pitcher"/> entities from the database
    /// </summary>
    /// <param name="name">The Name of the <see cref="Pitcher"/> requested</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection o <see cref="Pitcher"/> entities</returns>
    Task<List<Pitcher>> ReadPitcherByNameAsync(string name, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a collection of <see cref="Pitcher"/> entities from the database
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Team"/> requested</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="Pitcher"/> entities</returns>
    Task<List<Pitcher>> ReadAllPitchersByTeamIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates the value of a single <see cref="Pitcher"/> in the database
    /// </summary>
    /// <param name="pitcher">The <see cref="Pitcher"/> entity to be updated</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="Pitcher"/> does not exist in the database</exception>
    Task UpdatePitcherAsync(Pitcher pitcher, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Removes an existing <see cref="Pitcher"/> from the database
    /// </summary>
    /// <param name="id">The unique ID of the <see cref="Pitcher"/> to be deleted</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="Pitcher"/> does not exist in the database</exception>
    Task DeletePitcherByIdAsync(int id, CancellationToken cancellationToken = default);
}
