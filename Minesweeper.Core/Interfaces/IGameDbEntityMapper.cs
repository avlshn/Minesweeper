using Minesweeper.Core.Models;

namespace Minesweeper.Core.Interfaces;
/// <summary>
/// GameDbEntity mapper interface
/// </summary>
public interface IGameDbEntityMapper
{
    /// <summary>
    /// Maps GameDbEntity to Game
    /// </summary>
    /// <returns>Game entity</returns>
    public GameDbEntity GameToGameDbEntity(Game game);

    /// <summary>
    /// Maps Game to GameDbEntity
    /// </summary>
    /// <param name="dbEntity">Game DB entity to map</param>
    /// <returns>Game Entity</returns>
    public Game GameDbEntityToGame(GameDbEntity dbEntity);
}
