using Minesweeper.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Interfaces;

/// <summary>
/// Maps Game to GameDTO and back
/// </summary>

public interface IGameDTOMapper
{

    /// <summary>
    /// Maps gameDTO to Game.
    /// </summary>
    /// <param name="game">Game to map</param>
    /// <returns>Result of mapping</returns>
    public GameDTO MapToGameDTO(Game game);

    /// <summary>
    /// Maps gameDTO to Game.
    /// </summary>
    /// <param name="gameDTO">GameDTO to map</param>
    /// <returns>Result of mapping</returns>
    public Game MapToGame(GameDTO gameDTO);
}
