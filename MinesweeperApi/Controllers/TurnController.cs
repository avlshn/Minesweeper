using Microsoft.AspNetCore.Mvc;
using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Models;
using Minesweeper.Infrastructure.Services;

namespace MinesweeperApi.Controllers;

/// <summary>
/// Game turns requests controller
/// </summary>
[Route("api/turn")]
[ApiController]
public class TurnController : ControllerBase
{
    private readonly IGameLogic _gameLogic;
    /// <summary>
    /// Default DI constructor
    /// </summary>
    public TurnController(IGameLogic gameLogic)
    {
        _gameLogic = gameLogic;
    }

    /// <summary>
    /// Game turn requests
    /// </summary>
    /// <param name="turnDTO">Game turn info</param>
    /// <returns>DTO with updated game info</returns>
    [HttpPost(Name = "GetTurnResult")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GameDTO>> GetTurnResultAsync([FromBody] GameTurnRequest turnDTO)
    {
        
        if (turnDTO.row < 0 || turnDTO.col < 0)
        {
            return BadRequest(new { error = "Неверный индекс" });
        }

        GameDTO gameDTO;

            gameDTO = await _gameLogic.MakeTurnAsync(turnDTO);

        return Ok(gameDTO);
    }
}
