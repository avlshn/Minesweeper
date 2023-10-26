namespace MinesweeperApi.Models.DTO;

/// <summary>
/// DTO class with response information about game condition
/// </summary>
public class GameDTO
{
    public string game_id { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int mines_count { get; set; }
    public bool completed { get; set; }

    public string[][] field { get; set; }

}
