using Minesweeper.Core.Models;

namespace Minesweeper.Core.Interfaces;

/// <summary>
/// High level game logic
/// </summary>
public interface IGameLogic
{
    /// <summary>
    /// Creates new game, generates field, saves to Db, returns gameDTO
    /// </summary>
    /// <param name="gameInitDTO">Request with initial game information</param>
    /// <returns>Game DTO with new game</returns>
    public Task<GameDTO> CreateGameAsync(NewGameRequest gameInitDTO);

    /// <summary>
    /// Calculates turn, saves to Db, returns gameDTO
    /// </summary>
    /// <param name="gameTurnRequest">Request with turn information</param>
    /// <returns>Game DTO with updated game information</returns>
    /// <exception cref="ArgumentException">Turn processing error, see ex.message</exception>
    public Task<GameDTO> MakeTurnAsync(GameTurnRequest gameTurnRequest);
}

