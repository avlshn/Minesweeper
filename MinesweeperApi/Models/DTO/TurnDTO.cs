namespace MinesweeperApi.Models.DTO
{
    public record class TurnDTO(Guid game_id, int col, int row);
}
