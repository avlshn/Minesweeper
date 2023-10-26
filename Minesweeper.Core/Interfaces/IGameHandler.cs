using Minesweeper.Core.Models;

namespace Minesweeper.Core.Interfaces;

/// <summary>
/// Game process handler
/// </summary>
public interface IGameHandler
{
    /// <summary>
    /// Creates new game, based on request.
    /// </summary>
    /// <param name="gameInitDTO"></param>
    /// <returns>New game class with empty ID field</returns>
    public Game CreateGame(NewGameRequest gameInitDTO);

    /// <summary>
    /// Calculating turns. Opens field, checks if it is a mine or last free field.
    /// </summary>
    /// <param name="game">Game entity to process</param>
    /// <param name="turn">Turn request DTO</param>
    /// <returns>Game result, with field and completed changed, depending of turn result</returns>

    public Game GetTurnResult(Game game, GameTurnRequest turn);
}
