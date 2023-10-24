using MinesweeperApi.Models;
using MinesweeperApi.Models.Storage;
using System.Text.Json;

namespace MinesweeperApi.Servises;

public static class GameToGameDbEntityMapper
{
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

    public static Game GameDbEntityToGame(GameDbEntity dbEntity)
    {
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
