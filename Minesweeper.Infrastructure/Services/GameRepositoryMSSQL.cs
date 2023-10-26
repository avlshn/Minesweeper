using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Models;
using MinesweeperApi.Models.Storage;

namespace Minesweeper.Infrastructure.Services;

/// <summary>
/// Game repository for MSSQL
/// </summary>
public class GameRepositoryMSSQL : IGameRepository
{
    private readonly ApplicationDbContext _db;

    private readonly IGameDbEntityMapper _entityMapper;

    /// <summary>
    /// Default DI constructor
    /// </summary>
    /// <param name="db">DBContext</param>
    /// <param name="entityMapper">Game/gameDB entities mapper</param>
    public GameRepositoryMSSQL(ApplicationDbContext db, IGameDbEntityMapper entityMapper)
    {
        _db = db;
        _entityMapper = entityMapper;
    }

    /// <summary>
    /// Saves the new game to DB, generates guid.
    /// </summary>
    /// <param name="game">Game to save</param>
    /// <returns>Id of saved game</returns>
    public Guid SaveNewGame(Game game)
    {
        var entity = _entityMapper.GameToGameDbEntity(game);
        _db.Games.Add(entity);
        _db.SaveChanges();
        return entity.Id;
    }


    /// <summary>
    /// Gets game instance from DB by id
    /// </summary>
    /// <param name="id">Game ID</param>
    /// <returns>Game entity from DB</returns>
    public Game? GetGameById(Guid id)
    {
        var game = _db.Games.FirstOrDefault(x => x.Id == id);
        if (game != null)
            return _entityMapper.GameDbEntityToGame(game);
        else return null;
    }


    /// <summary>
    /// Updates game in DB
    /// </summary>
    /// <param name="game">Game to update</param>
    public void UpdateGame(Game game)
    {
        var saveGame = _db.Games.FirstOrDefault(x => x.Id == game.GameId);
        var gameDb = _entityMapper.GameToGameDbEntity(game);

        saveGame.TurnNumber = gameDb.TurnNumber;
        saveGame.MinesCount = gameDb.MinesCount;
        saveGame.Field = gameDb.Field;
        saveGame.IsCompleted = gameDb.IsCompleted;

        _db.SaveChanges();
    }
}
