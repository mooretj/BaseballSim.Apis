using System.Collections;
using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.Core.Interfaces;
/// <summary>
/// The Interface defining methods for managing <see cref="Batter"/> data within the database
/// </summary>
public interface IBatterRepository
{
    /// <summary>
    /// Add a <see cref="Batter"/> to the database
    /// </summary>
    /// <param name="batter">The <see cref="Batter"/> to be created</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <exception cref="DbUpdateException">An entity with the same ID already exists in the database</exception>
    void CreateBatterAsync(Batter batter, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a collection of <see cref="Batter"/> entities from the database
    /// </summary>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A task that represents the asynchronous operation. The result contains a collection of <see cref="Batter"/> enttites</returns>
    Task<List<Batter>> ReadAllBattersAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a collection of <see cref="Batter"/> entities from the database
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Team"/> requested</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A task that represents the asynchronous operation. The result contains a collection of <see cref="Batter"/> entities</returns>
    Task<List<Batter>> ReadAllBattersByTeamIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a single <see cref="Batter"/> entity from the database
    /// </summary>
    /// <param name="id">The unique identifier of <see cref="Batter"/> requested</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A task that represents the asynchronous operation. The result contains a <see cref="Batter"/> entity</returns>
    Task<Batter> ReadBatterByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a collection of <see cref="Batter"/> entities
    /// </summary>
    /// <param name="name">The Name of the <see cref="Batter"/> requested</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <returns>A task that represents the asynchronous operation. The result contains a collection of <see cref="Batter"/> entities</returns>
    Task<List<Batter>> ReadBattersByNameAsync(string name, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates the value of a single <see cref="Batter"/> entity in the database
    /// </summary>
    /// <param name="batter">The <see cref="Batter"/> entity to be updated</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="Batter"/> does not exist in the database</exception>
    void UpdateBatterAsync(Batter batter, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Removes an existing <see cref="Batter"/> from the database
    /// </summary>
    /// <param name="id">The unique ID of the <see cref="Batter"/> to be deleted</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="Batter"/> does not exist in the database</exception>
    void DeleteBatterByIdAsync(int id, CancellationToken cancellationToken = default);
}
