namespace MinesweeperApi.Models;

/// <summary>
/// Game data entity class
/// </summary>
public class Game
{
    public Guid game_id { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int mines_count { get; set; }
    public bool completed { get; set; }
    public string[][] field { get; set; }

    public int turn_number { get; set; }

}
