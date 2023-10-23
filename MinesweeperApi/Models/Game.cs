namespace MinesweeperApi.Models;

public class Game
{
    public Guid game_id { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int mines_count { get; set; }
    public bool completed { get; set; }
    public string[][] field { get; set; }

    public int turn_number { get; set; } = 0;

    public void Print()
    {
        Console.WriteLine($"Game ID: {game_id}\nWidth: {width}\nHeight: {height}\n" +
    $"Mines count: {mines_count}\nCompleted: {completed}");
        Console.WriteLine();
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Console.Write($"\"{field[x][y]}\" ");
            }
            Console.WriteLine();
        }
    }
}
