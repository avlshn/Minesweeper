namespace Minesweeper.Core.Models;


/// <summary>
/// Turn request DTO
/// </summary>
/// <param name="game_id"></param>
/// <param name="col"></param>
/// <param name="row"></param>
public record class GameTurnRequest(Guid game_id, int col, int row);
