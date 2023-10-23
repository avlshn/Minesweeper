using MinesweeperApi.Models;
using MinesweeperApi.Models.DTO;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace MinesweeperApi.Servises;

public static class GameDTOMapper
{
    public static GameDTO MapToGameDTO(Game game)
    {
        var gameDTO = new GameDTO(){
        game_id = game.game_id.ToString(),
        width = game.width,
        height = game.height,
        mines_count = game.mines_count,
        completed = game.completed,
        };

        gameDTO.field = game.field.Select(x => x.ToArray()).ToArray();
        //var tmpField = JsonSerializer.Serialize(game.field);
        //gameDTO.field = JsonSerializer.Deserialize<String[][]>(gameDTO.field);

        return gameDTO;
    }

    public static Game MapToGame(GameDTO gameDTO)
    {
        var game = new Game() {
            game_id = new Guid(gameDTO.game_id),
            width = gameDTO.width,
            height = gameDTO.height,
            mines_count = gameDTO.mines_count,
            completed = gameDTO.completed,
        };

        game.field = gameDTO.field.Select(x => x.ToArray()).ToArray();

        return game;
    }

}
