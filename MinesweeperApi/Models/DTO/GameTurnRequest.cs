namespace MinesweeperApi.Models.DTO
{
    public record class GameTurnRequest(Guid game_id, int col, int row);
}
