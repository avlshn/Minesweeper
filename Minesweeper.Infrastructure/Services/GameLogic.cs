using Minesweeper.Core.Exceptions;
using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Models;

namespace Minesweeper.Infrastructure.Services
{
    /// <summary>
    /// High level game logic class
    /// </summary>
    public class GameLogic : IGameLogic
    {

        private readonly IGameHandler _gameHandler;

        private readonly IGameRepository _gameRepository;

        private readonly IGameDTOMapper _gameDTOMapper;


        /// <summary>
        /// DI default constructor
        /// </summary>
        /// <param name="gameHandler">Game handler</param>
        /// <param name="gameRepository">Game repository</param>
        /// <param name="gameDTOMapper">Game to DTO mapper</param>
        public GameLogic(IGameHandler gameHandler, IGameRepository gameRepository, IGameDTOMapper gameDTOMapper)
        {
            _gameHandler = gameHandler;

            _gameRepository = gameRepository;

            _gameDTOMapper = gameDTOMapper;
        }

        /// <summary>
        /// Creates new game, generates field, saves to Db, returns gameDTO
        /// </summary>
        /// <param name="gameInitDTO">Request with initial game information</param>
        /// <returns>Game DTO with new game</returns>

        public async Task<GameDTO> CreateGameAsync(NewGameRequest gameInitDTO)
        {
            Game currentGame;

            currentGame = _gameHandler.CreateGame(gameInitDTO);

            currentGame.GameId = await _gameRepository.SaveNewGameAsync(currentGame);

            var gameDTO = _gameDTOMapper.MapToGameDTO(currentGame);

            return gameDTO;
        }

        /// <summary>
        /// Calculates turn, saves to Db, returns gameDTO
        /// </summary>
        /// <param name="gameTurnRequest">Request with turn information</param>
        /// <returns>Game DTO with updated game information</returns>
        /// <exception cref="ArgumentException">Turn processing error, see ex.message</exception>

        public async Task<GameDTO> MakeTurnAsync(GameTurnRequest gameTurnRequest)
        {
            var currentGame = await _gameRepository.GetGameByIdAsync(gameTurnRequest.game_id);

            if (currentGame == null)
            {
                throw new KeyNotFoundException("Игра с таким ID не найдена");
            }

            if (gameTurnRequest.row >= currentGame.Height || gameTurnRequest.col >= currentGame.Width)
            {
                throw new ArgumentOutOfRangeException("Неверный индекс");
            }

            if (currentGame.IsCompleted == true)
            {
                throw new GameCompletedException("Игра завершена");
            }


            currentGame = _gameHandler.GetTurnResult(currentGame, gameTurnRequest);



            await _gameRepository.UpdateGameAsync(currentGame);

            GameDTO gameDTO = _gameDTOMapper.MapToGameDTO(currentGame);

            return gameDTO;
        }
    }
}
