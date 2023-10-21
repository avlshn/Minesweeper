using Microsoft.AspNetCore.Mvc;
using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Controllers;

[Route("api/new")]
[ApiController]
public class NewGameController : ControllerBase
{

    [HttpPost(Name = "CreateGame")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<GameDTO> CreateGame([FromQuery] int width, [FromQuery] int height, [FromQuery] int mines_count)
    {
        if (width < 2 || width > 30)
        {
            return BadRequest("Ширина поля должна быть не менее 2 и не более 30");
        }

        if (height < 2 || height > 30)
        {
            return BadRequest("Высота поля должна быть не менее 2 и не более 30");
        }

        if (mines_count < 0 || mines_count > height * width - 1)
        {
            return BadRequest($"Количество мин должно быть не менее 1 и строго менее количества ячеек {height * width - 1}");
        }

        //Заглушка вместо БЛ
        Console.WriteLine($"Новая игра создана. Размер поля {width} на {height}. Количество мин - {mines_count}.");

        //Добавить вывод ДТО после обработки
        return Ok();
    }
}

