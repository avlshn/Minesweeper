namespace MinesweeperApi.Models.DTO;

/// <summary>
/// New game request DTO
/// </summary>
/// <param name="width"></param>
/// <param name="height"></param>
/// <param name="mines_count"></param>
public record class NewGameRequest(int width, int height, int mines_count);

