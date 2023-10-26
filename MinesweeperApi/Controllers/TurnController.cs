using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MinesweeperApi.Models.DTO;
using MinesweeperApi.Models.Storage;
using MinesweeperApi.Servises;

namespace MinesweeperApi.Controllers;

[Route("api/turn")]
[ApiController]

public class TurnController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public TurnController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpPost(Name = "GetTurnResult")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public ActionResult<GameDTO> GetTurnResult([FromBody] GameTurnRequest turnDTO)
    {
        
        if (turnDTO.row < 0 || turnDTO.col < 0)
        {
            return BadRequest(new ErrorResponse("Неверный индекс"));
        }

        var currentGame = DbQueries.GetGameById(turnDTO.game_id, _db);

        if (currentGame == null)
        {
            return BadRequest(new ErrorResponse("Игра с таким ID не найдена"));
        }

        if (turnDTO.row >= currentGame.height || turnDTO.col >= currentGame.width)
        {
            return BadRequest(new ErrorResponse("Неверный индекс"));
        }

        if (currentGame.completed == true)
        {
            return BadRequest(new ErrorResponse("Игра завершена"));
        }



        try
        {
            currentGame = GameTurn.GetTurnResult(currentGame, turnDTO);
        }
        catch (ArgumentNullException ex) 
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return BadRequest(new ErrorResponse(ex.Message));
        }
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    return StatusCode(StatusCodes.Status500InternalServerError);
        //}

        DbQueries.UpdateGame(currentGame, _db);

        GameDTO gameDTO = GameDTOMapper.MapToGameDTO(currentGame);

        gameDTO = FieldTransform.HideMines(gameDTO);
   
        return Ok(gameDTO);
    }
}
