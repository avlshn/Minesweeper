namespace MinesweeperApi.Models.DTO;

public record class NewGameRequest(int width, int height, int mines_count);

