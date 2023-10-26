using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Servises;

/// <summary>
/// Game field transformations in Game DTO before sending back
/// </summary>
public static class FieldTransform
{
    /// <summary>
    /// Hides mines on game field
    /// </summary>
    /// <param name="gameDTO"></param>
    /// <returns></returns>
    public static GameDTO HideMines(GameDTO gameDTO)
    {
        for (int x = 0; x < gameDTO.width; x++)
        {
            for (int y = 0; y < gameDTO.height; y++)
            {
                if (gameDTO.field[y][x] == "Q") gameDTO.field[y][x] = " ";
            }
        }
        return gameDTO;
    }
}
