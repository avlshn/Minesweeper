using MinesweeperApi.Models;
using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Servises;

public static class GameTurn
{
    public static Game GetTurnResult(Game game, GameTurnRequest turn)
    {
        if (game.field[turn.col][turn.row] != "Q" && game.field[turn.col][turn.row] != " ") throw new ArgumentOutOfRangeException("Уже открытая ячейка");

        var currentGame = game;
        
        if (game == null) throw new ArgumentNullException(nameof(game));
        if (turn == null) throw new ArgumentNullException(nameof(turn));

        if (game.field[turn.col][turn.row] == "Q" && !game.completed) return currentGame = GameOver(game);

        OpenCell(currentGame, turn.col, turn.row);

        if (currentGame.turn_number >= game.width * game.height - game.mines_count) return currentGame = Victory(currentGame);

        return currentGame;
    }

    private static Game Victory(Game game)
    {
        var currentGame = game;

        currentGame.completed = true;

        for (int x = 0; x < currentGame.width; x++)
        {
            for (int y = 0; y < currentGame.height; y++)
            {
                if (currentGame.field[x][y] == "Q") currentGame.field[x][y] = "M";
            }
        }

        return currentGame;
    }

    private static Game GameOver(Game game)
    {
        var currentGame = game;

        currentGame.completed = true;

        for (int x = 0; x < currentGame.width; x++)
        {
            for (int y = 0; y < currentGame.height; y++)
            {
                if (currentGame.field[x][y] == " ") OpenCell(currentGame, x, y);
                if (currentGame.field[x][y] == "Q") currentGame.field[x][y] = "X";
            }
        }

        return currentGame;
    }

    private static void OpenCell(Game game, int col, int row)
    {
        int neighboring_mines = 0;

        if (game.field[col][row] != " ") return;

        for (int i = 0; i < 9; i++)
        {
            int x = col + i % 3 - 1;
            int y = row + i / 3 - 1;

            if (x < 0 || x >= game.width) continue;
            if (y < 0 || y >= game.height) continue;

            if (game.field[x][y] == "Q" || game.field[x][y] == "M" || game.field[x][y] == "X") neighboring_mines++;
        }

        game.field[col][row] = neighboring_mines.ToString();

        game.turn_number++;

        if (neighboring_mines == 0)
        {
            for (int i = 0; i < 9; i++)
            {
                int x = col + i % 3 - 1;
                int y = row + i / 3 - 1;

                if (x < 0 || x >= game.width) continue;
                if (y < 0 || y >= game.height) continue;

                OpenCell(game, x, y);
            }
        }
    }
}
