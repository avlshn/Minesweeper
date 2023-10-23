using MinesweeperApi.Models;
using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Servises;

public static class CreateNewGame
{

    //Jugged array version
    public static Game CreateGame(GameInitDTO gameInitDTO)
    {
        Game game = new Game()
        {
            game_id = Guid.NewGuid(),
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

//public static class CreateNewGame
//{
//    public static GameDTO CreateGame(GameInitDTO game)
//    {
//        GameDTO gameDTO = new GameDTO()
//        {
//            game_id = Guid.NewGuid().ToString(),
//            completed = false,
//            height = game.height,
//            width = game.width,
//            mines_count = game.mines_count,
//            field = new string[game.width, game.height]
//        };

//        GenerateField(gameDTO);

//        return gameDTO;
//    }

//    private static void GenerateField(GameDTO game)
//    {
//        for (int x = 0; x < game.width; x++)
//        {
//            for (int y = 0; y < game.height; y++)
//            {
//                game.field[x, y] = " ";
//            }
//        }

//        int current_mines = 0;

//        while (current_mines < game.mines_count)
//        {
//            Random rnd = new Random();
//            int x = rnd.Next(game.width);
//            int y = rnd.Next(game.height);

//            if (game.field[x, y] == " ")
//            {
//                game.field[x, y] = "Q";
//                current_mines++;
//            }
//        }

//    }
//}
