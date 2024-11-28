using BaseballSim.Core.Models;
using BaseballSim.Protos;

namespace BaseballSim.Core.Interfaces;

/// <summary>
/// Represents a service for managing <see cref="Pitcher"/>
/// </summary>
public interface IPitchersService
{
 /// <summary>
 /// Retrieves a list of all <see cref="Pitcher"/>
 /// </summary>
 /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
 /// <returns>A list of <see cref="Pitcher"/></returns>
 Task<List<Pitcher>> GetAllPitchersAsync(CancellationToken cancellationToken = default);
 
 /// <summary>
 /// Retrieves a list of all <see cref="Pitcher"/> by <see cref="Team"/> Id
 /// </summary>
 /// <param name="teamId">The uniqued ID of the <see cref="Team"/> for which <see cref="Pitcher"/> should be retrieved</param>
 /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
 /// <returns>A list of <see cref="Pitcher"/></returns>
 Task<List<Pitcher>> GetAllPitchersByTeamIdAsync(int teamId, CancellationToken cancellationToken = default);
 
 /// <summary>
 /// Retrieves a list of <see cref="Pitcher"/> by their name
 /// </summary>
 /// <param name="name">The name of the <see cref="Pitcher"/> to retrieve</param>
 /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
 /// <returns>A list of <see cref="Pitcher"/></returns>
 Task<List<Pitcher>> GetAllPitchersByNameAsync(string name, CancellationToken cancellationToken = default);
 
 /// <summary>
 /// Retrieves a <see cref="Pitcher"/> by its ID
 /// </summary>
 /// <param name="pitcherId">The unique ID of the <see cref="Pitcher"/> to retrieve</param>
 /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
 /// <returns>A single <see cref="Pitcher"/></returns>
 Task<Pitcher> GetPitcherByIdAsync(int pitcherId, CancellationToken cancellationToken = default);
 
 /// <summary>
 /// Creates a new <see cref="Pitcher"/>
 /// </summary>
 /// <param name="pitcher">The <see cref="Pitcher"/> to be created</param>
 /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
 /// <returns></returns>
 Task<EmptyPitcherResponse> CreatePitcherAsync(Pitcher pitcher, CancellationToken cancellationToken = default);
 
 /// <summary>
 /// Updates an existing <see cref="Pitcher"/>
 /// </summary>
 /// <param name="pitcher">The <see cref="Pitcher"/> to be updated</param>
 /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
 /// <returns></returns>
 Task<EmptyPitcherResponse> UpdatePitcherAsync(Pitcher pitcher, CancellationToken cancellationToken = default);
 
 /// <summary>
 /// Deletes an existing <see cref="Pitcher"/>
 /// </summary>
 /// <param name="pitcherId">The unique ID of the <see cref="Pitcher"/> to be deleted</param>
 /// <param name="cancellationToken">The cancellation token used to cancel the DB request</param>
 /// <returns></returns>
 Task<EmptyPitcherResponse> DeletePitcherAsync(int pitcherId, CancellationToken cancellationToken = default);
}
