using MinesweeperApi.Models;
using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Servises;

/// <summary>
/// Service class with methods to create new game
/// </summary>
public static class CreateNewGame
{
    /// <summary>
    /// Creates new game, based on request.
    /// </summary>
    /// <param name="gameInitDTO"></param>
    /// <returns>New game class with empty ID field</returns>
    public static Game CreateGame(NewGameRequest gameInitDTO)
    {
        Game game = new Game()
        {
            completed = false,
            height = gameInitDTO.height,
            width = gameInitDTO.width,
            mines_count = gameInitDTO.mines_count,
            field = new string[gameInitDTO.height][]
        };

        for (int i = 0; i < gameInitDTO.height; i++)
            game.field[i] = new string[gameInitDTO.width];

        GenerateField(game);

        return game;
    }


    /// <summary>
    /// Field generation
    /// </summary>
    /// <param name="game"></param>
    private static void GenerateField(Game game)
    {
        for (int x = 0; x < game.width; x++)
        {
            for (int y = 0; y < game.height; y++)
            {
                game.field[y][x] = " ";
            }
        }

        int current_mines = 0;

        while (current_mines < game.mines_count)
        {
            Random rnd = new Random();
            int x = rnd.Next(game.width);
            int y = rnd.Next(game.height);

            if (game.field[y][x] == " ")
            {
                game.field[y][x] = "Q";
                current_mines++;
            }
        }

    }
}

