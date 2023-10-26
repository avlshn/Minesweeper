using MinesweeperApi.Models;
using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Servises;

/// <summary>
/// Making turns, checking victory and loose conditions.
/// </summary>
public static class GameTurn
{
    /// <summary>
    /// Calculating turns. Opens field, checks if it is a mine or last free field.
    /// </summary>
    /// <param name="game">Game entity to process</param>
    /// <param name="turn">Turn request DTO</param>
    /// <returns>Game result, with field and completed changed, depending of turn result</returns>
    /// <exception cref="ArgumentOutOfRangeException">Cell is already opened</exception>
    /// <exception cref="ArgumentNullException">Throws if one of arguments is null.</exception>
    public static Game GetTurnResult(Game game, GameTurnRequest turn)
    {
        if (game.field[turn.row][turn.col] != "Q" && game.field[turn.row][turn.col] != " ") throw new ArgumentOutOfRangeException("Уже открытая ячейка");

        var currentGame = game;
        
        if (game == null) throw new ArgumentNullException(nameof(game));
        if (turn == null) throw new ArgumentNullException(nameof(turn));

        if (game.field[turn.row][turn.col] == "Q" && !game.completed) return currentGame = GameOver(game);

        OpenCell(currentGame, turn.row, turn.col);

        if (currentGame.turn_number >= game.width * game.height - game.mines_count) return currentGame = Victory(currentGame);

        return currentGame;
    }

    /// <summary>
    /// Final changes in entity when game is won.
    /// </summary>
    /// <param name="game">Game entity to process</param>
    /// <returns>Game object with completed changed to true, field opened and mines opened</returns>
    private static Game Victory(Game game)
    {
        var currentGame = game;

        currentGame.completed = true;

        for (int x = 0; x < currentGame.width; x++)
        {
            for (int y = 0; y < currentGame.height; y++)
            {
                if (currentGame.field[y][x] == "Q") currentGame.field[y][x] = "M";
            }
        }

        return currentGame;
    }
    /// <summary>
    /// Final changes in entity when game is lost.
    /// </summary>
    /// <param name="game">Game entity to process</param>
    /// <returns>Game object with completed changed to true, and mines opened</returns>
    private static Game GameOver(Game game)
    {
        var currentGame = game;

        currentGame.completed = true;

        for (int x = 0; x < currentGame.width; x++)
        {
            for (int y = 0; y < currentGame.height; y++)
            {
                if (currentGame.field[y][x] == " ") OpenCell(currentGame, y, x);
                if (currentGame.field[y][x] == "Q") currentGame.field[y][x] = "X";
            }
        }

        return currentGame;
    }
    /// <summary>
    /// Opens cell, counts neigboring mines if it is zero - recursively opens surrounding cells
    /// </summary>
    /// <param name="game">Game entity to process</param>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    private static void OpenCell(Game game, int row, int col)
    {
        int neighboring_mines = 0;

        if (game.field[row][col] != " ") return;

        for (int i = 0; i < 9; i++)
        {
            if (i == 4) continue;

            int x = col + i % 3 - 1;
            int y = row + i / 3 - 1;

            if (x < 0 || x >= game.width) continue;
            if (y < 0 || y >= game.height) continue;

            if (game.field[y][x] == "Q" || game.field[y][x] == "M" || game.field[y][x] == "X") neighboring_mines++;
        }

        game.field[row][col] = neighboring_mines.ToString();

        game.turn_number++;

        if (neighboring_mines == 0)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i == 4) continue;

                int x = col + i % 3 - 1;
                int y = row + i / 3 - 1;

                if (x < 0 || x >= game.width) continue;
                if (y < 0 || y >= game.height) continue;

                OpenCell(game, y, x);
            }
        }
    }
}
