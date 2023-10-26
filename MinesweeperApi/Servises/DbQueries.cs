﻿using Microsoft.IdentityModel.Tokens;
using MinesweeperApi.Models;
using MinesweeperApi.Models.Storage;

namespace MinesweeperApi.Servises;

/// <summary>
/// DB queries service class
/// </summary>
public static class DbQueries
{
    /// <summary>
    /// Saves the new game to DB, generates guid.
    /// </summary>
    /// <param name="game">Game to save</param>
    /// <param name="db">Db context</param>
    /// <returns>Id of saved game</returns>
    public static Guid SaveNewGame(Game game, ApplicationDbContext db)
    {
        var entity = GameToGameDbEntityMapper.GameToGameDbEntity(game);
        db.Games.Add(entity);
        db.SaveChanges();
        return entity.Id;
    }


    /// <summary>
    /// Gets game instance from DB by id
    /// </summary>
    /// <param name="id">Game ID</param>
    /// <param name="db">Db context</param>
    /// <returns>Game entity from DB</returns>
    public static Game? GetGameById(Guid id, ApplicationDbContext db)
    {
        var game = db.Games.FirstOrDefault(x => x.Id == id);
        if (game != null)
            return GameToGameDbEntityMapper.GameDbEntityToGame(game);
        else return null;
    }


    /// <summary>
    /// Updates game in DB
    /// </summary>
    /// <param name="game">Game to update</param>
    /// <param name="db">Db context</param>
    public static void UpdateGame(Game game, ApplicationDbContext db)
    {
        var saveGame = db.Games.FirstOrDefault(x => x.Id == game.game_id);
        var gameDb = GameToGameDbEntityMapper.GameToGameDbEntity(game);

        saveGame.turn_number = gameDb.turn_number;
        saveGame.mines_count = gameDb.mines_count;
        saveGame.field = gameDb.field;
        saveGame.completed = gameDb.completed;

        db.SaveChanges();
    }
}
