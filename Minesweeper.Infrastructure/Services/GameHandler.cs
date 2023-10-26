using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Models;

namespace MinesweeperApi.Servises
{
    /// <summary>
    /// Game process handler
    /// </summary>
    public class GameHandler : IGameHandler
    {
        /// <summary>
        /// Creates new game, based on request.
        /// </summary>
        /// <param name="gameInitDTO"></param>
        /// <returns>New game class with empty ID field</returns>
        public Game CreateGame(NewGameRequest gameInitDTO)
        {
            Game game = new Game()
            {
                IsCompleted = false,
                Height = gameInitDTO.height,
                Width = gameInitDTO.width,
                MinesCount = gameInitDTO.mines_count,
                Field = new string[gameInitDTO.height][]
            };

            for (int i = 0; i < gameInitDTO.height; i++)
                game.Field[i] = new string[gameInitDTO.width];

            GenerateField(game);

            return game;
        }


        /// <summary>
        /// Field generation
        /// </summary>
        /// <param name="game"></param>
        private void GenerateField(Game game)
        {
            for (int x = 0; x < game.Width; x++)
            {
                for (int y = 0; y < game.Height; y++)
                {
                    game.Field[y][x] = " ";
                }
            }

            int current_mines = 0;

            while (current_mines < game.MinesCount)
            {
                Random rnd = new Random();
                int x = rnd.Next(game.Width);
                int y = rnd.Next(game.Height);

                if (game.Field[y][x] == " ")
                {
                    game.Field[y][x] = "Q";
                    current_mines++;
                }
            }

        }

        /// <summary>
        /// Calculating turns. Opens field, checks if it is a mine or last free field.
        /// </summary>
        /// <param name="game">Game entity to process</param>
        /// <param name="turn">Turn request DTO</param>
        /// <returns>Game result, with field and completed changed, depending of turn result</returns>
        /// <exception cref="ArgumentOutOfRangeException">Cell is already opened</exception>
        /// <exception cref="ArgumentNullException">Throws if one of arguments is null.</exception>
        public Game GetTurnResult(Game game, GameTurnRequest turn)
        {
            if (game.Field[turn.row][turn.col] != "Q" && game.Field[turn.row][turn.col] != " ") throw new ArgumentOutOfRangeException("Уже открытая ячейка");

            var currentGame = game;

            if (game == null) throw new ArgumentNullException(nameof(game));
            if (turn == null) throw new ArgumentNullException(nameof(turn));

            if (game.Field[turn.row][turn.col] == "Q" && !game.IsCompleted) return currentGame = GameOver(game);

            OpenCell(currentGame, turn.row, turn.col);

            if (currentGame.TurnNumber >= game.Width * game.Height - game.MinesCount) return currentGame = Victory(currentGame);

            return currentGame;
        }

        /// <summary>
        /// Final changes in entity when game is won.
        /// </summary>
        /// <param name="game">Game entity to process</param>
        /// <returns>Game object with completed changed to true, field opened and mines opened</returns>
        private Game Victory(Game game)
        {
            var currentGame = game;

            currentGame.IsCompleted = true;

            for (int x = 0; x < currentGame.Width; x++)
            {
                for (int y = 0; y < currentGame.Height; y++)
                {
                    if (currentGame.Field[y][x] == "Q") currentGame.Field[y][x] = "M";
                }
            }

            return currentGame;
        }
        /// <summary>
        /// Final changes in entity when game is lost.
        /// </summary>
        /// <param name="game">Game entity to process</param>
        /// <returns>Game object with completed changed to true, and mines opened</returns>
        private Game GameOver(Game game)
        {
            var currentGame = game;

            currentGame.IsCompleted = true;

            for (int x = 0; x < currentGame.Width; x++)
            {
                for (int y = 0; y < currentGame.Height; y++)
                {
                    if (currentGame.Field[y][x] == " ") OpenCell(currentGame, y, x);
                    if (currentGame.Field[y][x] == "Q") currentGame.Field[y][x] = "X";
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

            if (game.Field[row][col] != " ") return;

            for (int i = 0; i < 9; i++)
            {
                if (i == 4) continue;

                int x = col + i % 3 - 1;
                int y = row + i / 3 - 1;

                if (x < 0 || x >= game.Width) continue;
                if (y < 0 || y >= game.Height) continue;

                if (game.Field[y][x] == "Q" || game.Field[y][x] == "M" || game.Field[y][x] == "X") neighboring_mines++;
            }

            game.Field[row][col] = neighboring_mines.ToString();

            game.TurnNumber++;

            if (neighboring_mines == 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i == 4) continue;

                    int x = col + i % 3 - 1;
                    int y = row + i / 3 - 1;

                    if (x < 0 || x >= game.Width) continue;
                    if (y < 0 || y >= game.Height) continue;

                    OpenCell(game, y, x);
                }
            }
        }
    }
}
