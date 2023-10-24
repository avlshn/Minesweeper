namespace MinesweeperApi.Models.DTO
{
    public class GameDTO
    {
        public string game_id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int mines_count { get; set; }
        public bool completed { get; set; }

        public string[][] field { get; set; }

        /// <summary>
        /// Тестовый метод, убрать
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Game ID: {game_id}\nWidth: {width}\nHeight: {height}\n" +
        $"Mines count: {mines_count}\nCompleted: {completed}");
            Console.WriteLine();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write($"\"{field[x][y]}\" ");
                }
                Console.WriteLine();
            }
        }
    }
}
