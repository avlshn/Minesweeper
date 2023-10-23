using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Servises;

public static class FieldTransform
{
    public static GameDTO HideMines(GameDTO gameDTO)
    {
        for (int x = 0; x < gameDTO.width; x++)
        {
            for (int y = 0; y < gameDTO.height; y++)
            {
                if (gameDTO.field[x][y] == "Q") gameDTO.field[x][y] = " ";
            }
        }
        return gameDTO;
    }
}
