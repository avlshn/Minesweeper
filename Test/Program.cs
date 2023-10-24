// See https://aka.ms/new-console-template for more information

using MinesweeperApi.Models.DTO;
using MinesweeperApi.Models.Storage;
using MinesweeperApi.Servises;

NewGameRequest gameInitDTO = new NewGameRequest(20, 10, 40);


var game = CreateNewGame.CreateGame(gameInitDTO);

GameTurnRequest turnDTO1 = new GameTurnRequest(game.game_id, 9, 9);
GameTurnRequest turnDTO2 = new GameTurnRequest(game.game_id, 6, 5);
GameTurnRequest turnDTO3 = new GameTurnRequest(game.game_id, 7, 5);
GameTurnRequest turnDTO4 = new GameTurnRequest(game.game_id, 8, 5);
GameTurnRequest turnDTO5 = new GameTurnRequest(game.game_id, 9, 5);

GameDTO gameDTO;

game.Print();

//DbEmul.Storage.Add(game.game_id, game);

//game = GameTurn.GetTurnResult(game, turnDTO1);
//game.Print();
//Console.ReadKey();

//game = GameTurn.GetTurnResult(game, turnDTO2);
//game.Print();
//Console.ReadKey();

//game = GameTurn.GetTurnResult(game, turnDTO3);
//game.Print();
//Console.ReadKey();

//game = GameTurn.GetTurnResult(game, turnDTO4);
//game.Print();
//Console.ReadKey();

game = GameTurn.GetTurnResult(game, turnDTO5);
game.Print();
Console.ReadKey();

var db = GameToGameDbEntityMapper.GameToGameDbEntity(game);

var game2 = GameToGameDbEntityMapper.GameDbEntityToGame(db);
game2.Print();
Console.ReadKey();

#region Test mapping
//gameDTO = GameDTOMapper.MapToGameDTO(game);

//gameDTO.Print();

//gameDTO = FieldTransform.HideMines(gameDTO);

//Console.WriteLine();
//Console.WriteLine();

//gameDTO.Print();

//dbEmul.Storage[game.game_id].Print();
#endregion


Console.ReadKey();
