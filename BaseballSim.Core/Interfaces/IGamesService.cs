using BaseballSim.Core.Models;
using BaseballSim.Protos;

namespace BaseballSim.Core.Interfaces;

/// <summary>
/// Represents a service for managing Games
/// </summary>
public interface IGamesService
{
    /// <summary>
    /// Retrieves a list of all <see cref="Game"/>
    /// </summary>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns>A list of <see cref="Game"/></returns>
    Task<List<Game>> GetAllGamesAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a list of all Games for a specific team
    /// </summary>
    /// <param name="teamId">The unique ID of the Team for which Games should be retrieved</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Game>> GetGamesByTeamIdAsync(int teamId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a single Game by its ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns>A single <see cref="Game"/></returns>
    Task<Game> GetGameByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Creates a new Game
    /// </summary>
    /// <param name="game">The Game to be created</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns></returns>
    Task<EmptyGameResponse> CreateGameAsync(Game game, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an existing <see cref="Game"/>
    /// </summary>
    /// <param name="game">The Game to be updated</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns></returns>
    Task<EmptyGameResponse> UpdateGameAsync(Game game, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes an existing Game
    /// </summary>
    /// <param name="id">The unique ID of the Game to be deleted</param>
    /// <param name="cancellationToken">The cancellation token used to cancel the DB Request</param>
    /// <returns></returns>
    Task<EmptyGameResponse> DeleteGameAsync(int id, CancellationToken cancellationToken = default);
}
