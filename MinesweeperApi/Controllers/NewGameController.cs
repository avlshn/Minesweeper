using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MinesweeperApi.Models;
using MinesweeperApi.Models.DTO;
using MinesweeperApi.Models.Storage;
using MinesweeperApi.Servises;

namespace MinesweeperApi.Controllers;

[Route("api/new")]
[ApiController]

public class NewGameController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public NewGameController(ApplicationDbContext db)
    {
        _db = db;
    }

    //[HttpOptions]
    //public string OptionsNewGame()
    //{
    //    return null;
    //}

    [HttpPost(Name = "CreateGame")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<GameDTO> CreateGame([FromBody] NewGameRequest gameInitDTO)
    {
        
        if (gameInitDTO.width < 2 || gameInitDTO.width > 30)
        {
            return BadRequest("Ширина поля должна быть не менее 2 и не более 30");
        }

        if (gameInitDTO.height < 2 || gameInitDTO.height > 30)
        {
            return BadRequest("Высота поля должна быть не менее 2 и не более 30");
        }

        if (gameInitDTO.mines_count < 0 || gameInitDTO.mines_count > gameInitDTO.height * gameInitDTO.width - 1)
        {
            return BadRequest($"Количество мин должно быть не менее 1 и строго менее количества ячеек {gameInitDTO.height * gameInitDTO.width - 1}");
        }

        Game currentGame;

        try
        {
            currentGame = CreateNewGame.CreateGame(gameInitDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        currentGame.game_id = DbQueries.SaveNewGame(currentGame, _db);

        var gameDTO = GameDTOMapper.MapToGameDTO(currentGame);
        FieldTransform.HideMines(gameDTO);

        Console.WriteLine($"Новая игра создана. Размер поля {gameInitDTO.width} на {gameInitDTO.height}. Количество мин - {gameInitDTO.mines_count}.");

        //Добавить возврат ДТО GameDTO после обработки
        return Ok(gameDTO);
    }
}

