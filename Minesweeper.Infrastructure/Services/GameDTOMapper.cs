using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Models;

namespace Minesweeper.Infrastructure.Services;

/// <summary>
/// Game to GameDTO and back mapper class
/// </summary>
public class GameDTOMapper : IGameDTOMapper
{

    /// <summary>
    /// Maps gameDTO to Game.
    /// </summary>
    /// <param name="game">Game to map</param>
    /// <returns>Result of mapping</returns>

    public GameDTO MapToGameDTO(Game game)
    {
        var gameDTO = new GameDTO()
        {
            GameId = game.GameId.ToString(),
            Width = game.Width,
            Height = game.Height,
            MinesCount = game.MinesCount,
            IsCompleted = game.IsCompleted,
        };

        gameDTO.Field = game.Field.Select(x => x.ToArray()).ToArray();
        gameDTO = HideMines(gameDTO);
        return gameDTO;
    }

    /// <summary>
    /// Maps gameDTO to Game. Virtual, not implemented.
    /// </summary>
    /// <param name="gameDTO">GameDTO to map</param>
    /// <returns>Result of mapping</returns>
    public virtual Game MapToGame(GameDTO gameDTO)
    {

        throw new NotImplementedException();
    }

    /// <summary>
    /// Hides mines on game field
    /// </summary>
    /// <param name="gameDTO">Game DTO to hide mines</param>
    /// <returns>Game DTO without mines on field</returns>
    private GameDTO HideMines(GameDTO gameDTO)
    {
        for (int x = 0; x < gameDTO.Width; x++)
        {
            for (int y = 0; y < gameDTO.Height; y++)
            {
                if (gameDTO.Field[y][x] == "Q") gameDTO.Field[y][x] = " ";
            }
        }
        return gameDTO;
    }
}
