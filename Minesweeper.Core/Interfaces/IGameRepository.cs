using Minesweeper.Core.Models;

namespace Minesweeper.Core.Interfaces;

/// <summary>
/// Game repository
/// </summary>
public interface IGameRepository
{
    /// <summary>
    /// Saves the new game to DB, generates guid.
    /// </summary>
    /// <param name="game">Game to save</param>
    /// <returns>Id of saved game</returns>
    public Task<Guid> SaveNewGameAsync(Game game);

    /// <summary>
    /// Gets game instance from DB by id
    /// </summary>
    /// <param name="id">Game ID</param>
    /// <returns>Game entity from DB</returns>
    public Task<Game?> GetGameByIdAsync(Guid id);

    /// <summary>
    /// Updates game in DB
    /// </summary>
    /// <param name="game">Game to update</param>

    public Task UpdateGameAsync(Game game);

}


