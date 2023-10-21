using Microsoft.AspNetCore.Mvc;
using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Controllers;

[Route("api/turn")]
[ApiController]
public class TurnController : ControllerBase
{
    [HttpPost(Name = "GetTurnResult")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public ActionResult<GameDTO> GetTurnResult([FromQuery] string game_id, [FromQuery] int row, [FromQuery] int col)
    {
        if (row < 0 || col < 0)
        {
            return BadRequest();
        }

        //Вызов функции обработки, если game_id не существует получить ошибку, если игра завершена
        //или указана уже открытая ячейка.
        //в противном случае - результат.

        Console.WriteLine("Ход успешно сделан");
        return Ok();

    }
}
