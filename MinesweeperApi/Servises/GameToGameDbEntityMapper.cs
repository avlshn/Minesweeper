using MinesweeperApi.Models;
using MinesweeperApi.Models.Storage;
using System.Text.Json;

namespace MinesweeperApi.Servises;

/// <summary>
/// Game to GameDb and back mapper secrice class
/// </summary>
public static class GameToGameDbEntityMapper
{
    /// <summary>
    /// Maps Game to GameDbEntity
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static GameDbEntity GameToGameDbEntity(Game game)
    {
        var dbEntity = new GameDbEntity()
        {
            mines_count = game.mines_count,
            completed = game.completed,
            turn_number = game.turn_number
        };

        dbEntity.field = JsonSerializer.Serialize(game.field);

        return dbEntity;
    }
    /// <summary>
    /// Maps GameDbEntity to Game
    /// </summary>
    /// <param name="dbEntity"></param>
    /// <returns></returns>
    public static Game GameDbEntityToGame(GameDbEntity dbEntity)
    {
        if (dbEntity == null) throw new ArgumentNullException(nameof(dbEntity));

        var game = new Game()
        {
            game_id = dbEntity.Id,
            mines_count = dbEntity.mines_count,
            completed = dbEntity.completed,
            turn_number = dbEntity.turn_number
        };

        if (game != null)
        game.field = JsonSerializer.Deserialize<string[][]>(dbEntity.field);

        game.width = game.field.Length;
        game.height = game.field[0].Length;

        return game;
    }
}
