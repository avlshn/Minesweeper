using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Models;
using System.Text.Json;

namespace Minesweeper.Infrastructure.Services;

/// <summary>
/// Game to GameDb and back mapper class
/// </summary>
public class GameToGameDbEntityMapper : IGameDbEntityMapper
{
    /// <summary>
    /// Maps Game to GameDbEntity
    /// </summary>
    /// <param name="game">Game entity</param>
    /// <returns>Game DB entity</returns>
    public GameDbEntity GameToGameDbEntity(Game game)
    {
        var dbEntity = new GameDbEntity()
        {
            MinesCount = game.MinesCount,
            IsCompleted = game.IsCompleted,
            TurnNumber = game.TurnNumber
        };

        dbEntity.Field = JsonSerializer.Serialize(game.Field);

        return dbEntity;
    }
    /// <summary>
    /// Maps GameDbEntity to Game
    /// </summary>
    /// <param name="dbEntity">Game DB entity</param>
    /// <returns>Game entity</returns>
    public Game GameDbEntityToGame(GameDbEntity dbEntity)
    {
        if (dbEntity == null) throw new ArgumentNullException(nameof(dbEntity));

        var game = new Game()
        {
            GameId = dbEntity.Id,
            MinesCount = dbEntity.MinesCount,
            IsCompleted = dbEntity.IsCompleted,
            TurnNumber = dbEntity.TurnNumber
        };

        if (game != null)
            game.Field = JsonSerializer.Deserialize<string[][]>(dbEntity.Field);

        game.Height = game.Field.Length;
        game.Width = game.Field[0].Length;

        return game;
    }
}
