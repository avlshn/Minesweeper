using Microsoft.AspNetCore.Mvc;
using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Models;

namespace MinesweeperApi.Controllers;
/// <summary>
/// New game requests controller
/// </summary>
[Route("api/new")]
[ApiController]

public class NewGameController : ControllerBase
{
    private readonly IGameLogic _gameLogic;

    /// <summary>
    /// Default DI constructor
    /// </summary>
    /// <param name="gameLogic">High level game logic interface</param>
    public NewGameController(IGameLogic gameLogic)
    {
        _gameLogic = gameLogic;
    }

    /// <summary>
    /// New game request
    /// </summary>
    /// <param name="gameInitDTO">Game initialization info</param>
    /// <returns>DTO with game info</returns>
    [HttpPost(Name = "CreateGame")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GameDTO>> CreateGameAsync([FromBody] NewGameRequest gameInitDTO)
    {


        
        if (gameInitDTO.width < 2 || gameInitDTO.width > 30)
        {
            return BadRequest(new { error = "Ширина поля должна быть не менее 2 и не более 30" });
        }

        if (gameInitDTO.height < 2 || gameInitDTO.height > 30)
        {
            return BadRequest(new { error = "Высота поля должна быть не менее 2 и не более 30" });
        }

        if (gameInitDTO.mines_count < 0 || gameInitDTO.mines_count > gameInitDTO.height * gameInitDTO.width - 1)
        {
            return BadRequest(new { error = $"Количество мин должно быть не менее 1 и строго менее количества ячеек {gameInitDTO.height * gameInitDTO.width - 1}" });
        }

        GameDTO newGame;

        newGame = await _gameLogic.CreateGameAsync(gameInitDTO);


        return Ok(newGame);
    }
}

