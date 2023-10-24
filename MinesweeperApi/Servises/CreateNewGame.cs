using MinesweeperApi.Models;
using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Servises;

public static class CreateNewGame
{

    //Jugged array version
    public static Game CreateGame(NewGameRequest gameInitDTO)
    {
        Game game = new Game()
        {
            completed = false,
            height = gameInitDTO.height,
            width = gameInitDTO.width,
            mines_count = gameInitDTO.mines_count,
            field = new string[gameInitDTO.width][]
        };

        for (int i = 0; i < gameInitDTO.width; i++)
            game.field[i] = new string[gameInitDTO.height];

        GenerateField(game);

        return game;
    }

    private static void GenerateField(Game game)
    {
        for (int x = 0; x < game.width; x++)
        {
            for (int y = 0; y < game.height; y++)
            {
                game.field[x][y] = " ";
            }
        }

        int current_mines = 0;

        while (current_mines < game.mines_count)
        {
            Random rnd = new Random();
            int x = rnd.Next(game.width);
            int y = rnd.Next(game.height);

            if (game.field[x][y] == " ")
            {
                game.field[x][y] = "Q";
                current_mines++;
            }
        }

    }
}

