using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.Core.Interfaces;

/// <summary>
/// The Interface defining methos for managing games data within the database
/// </summary>
public interface IGameRepository
{
    /// <summary>
    /// Add a <see cref="Game"/> to the database
    /// </summary>
    /// <param name="game">The <see cref="Game"/> to be created</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <exception cref="DbUpdateException">An entity with the same ID already exists in the database</exception>
    Task<Game> CreateGameAsync(Game game, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a collection of <see cref="Game"/> entities from the database
    /// </summary>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns>A task that represents the asynchronous operation. The result contains a collection of <see cref="Game"/> entities</returns>
    Task<List<Game>> ReadAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a collection <see cref="Game"/> entities from the database
    /// </summary>
    /// <param name="id">The ID of the <see cref="Team"/> requested</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <exception cref="InvalidOperationException">Thrown when the Team ID does not exist in the database</exception>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="Game"/> entities</returns>
    Task<List<Game>> ReadAllByTeamIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a single <see cref="Game"/> entity from the database
    /// </summary>
    /// <param name="id">The unique ID of the <see cref="Game"/> requested</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <exception cref="InvalidOperationException">Thrown when the Game does not exist in the database</exception>
    /// <returns>A task represents the asynchronous operation. The task result contains a single <see cref="Game"/> entity</returns>
    Task<Game> ReadGameByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates the value of a single <see cref="Game"/> in the database
    /// </summary>
    /// <param name="game">The Game object to be updated</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <exception cref="InvalidOperationException">Thrown when the Game does not exist in the Database</exception>
    Task UpdateGameAsync(Game game, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Removes an existing <see cref="Game"/> from the database
    /// </summary>
    /// <param name="id">The unique ID of the <see cref="Game"/> to be deleted</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="Game"/> does not exist in the database</exception>
    Task DeleteGameAsync(int id, CancellationToken cancellationToken = default);
}
