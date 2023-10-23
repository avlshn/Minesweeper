// See https://aka.ms/new-console-template for more information

using MinesweeperApi.Models.DTO;
using MinesweeperApi.Models.Storage;
using MinesweeperApi.Servises;

GameInitDTO gameInitDTO = new GameInitDTO(10, 10, 10);


var game = CreateNewGame.CreateGame(gameInitDTO);

TurnDTO turnDTO1 = new TurnDTO(game.game_id, 9, 9);
TurnDTO turnDTO2 = new TurnDTO(game.game_id, 6, 5);
TurnDTO turnDTO3 = new TurnDTO(game.game_id, 7, 5);
TurnDTO turnDTO4 = new TurnDTO(game.game_id, 8, 5);
TurnDTO turnDTO5 = new TurnDTO(game.game_id, 9, 5);

GameDTO gameDTO;
DbEmul dbEmul = new DbEmul();

game.Print();

dbEmul.Storage.Add(game.game_id, game);

game = GameTurn.GetTurnResult(game, turnDTO1);
game.Print();
Console.ReadKey();

game = GameTurn.GetTurnResult(game, turnDTO2);
game.Print();
Console.ReadKey();

game = GameTurn.GetTurnResult(game, turnDTO3);
game.Print();
Console.ReadKey();

game = GameTurn.GetTurnResult(game, turnDTO4);
game.Print();
Console.ReadKey();

game = GameTurn.GetTurnResult(game, turnDTO5);
game.Print();
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
