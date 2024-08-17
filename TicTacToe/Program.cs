namespace TicTacToe
{
    class Program
    {
        private static string[] Grid = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
        
        public static void Main(string[] args)
        {
            var currentPlayer = true;
            var numTurns = 0;
            while (!CheckVictory() && numTurns != 9)
            {
                PrintGrid();

                Console.WriteLine(currentPlayer ? "ХОД ИГРОКА: Х!" : "ХОД ИГРОКА: Y!");

                var choice = Console.ReadLine();

                if (Grid.Contains(choice) && choice != "X" && choice != "O")
                {
                    var gridIndex = Convert.ToInt32(choice) - 1;

                    if (currentPlayer)
                        Grid[gridIndex] = "X";
                    else
                        Grid[gridIndex] = "O";

                    numTurns++;
                    currentPlayer = !currentPlayer;
                    Console.WriteLine(numTurns);
                }
            }
            PrintGrid();
            Console.WriteLine(CheckVictory() ? "Вы победили!" : "Ничья!");
        }
        
        private static void PrintGrid()
        {
            const int rang = 3;
            for (int i = 0; i < rang; i++)
            {
                for (int j = 0; j < rang; j++)
                {
                    Console.Write(Grid[i * 3 + j] + "|");
                }

                Console.WriteLine("");
                Console.WriteLine("------");
            }
        }

        private static bool CheckVictory()
        {
            var row1 = Grid[0] == Grid[1] && Grid[1] == Grid[2]; 
            var row2 = Grid[3] == Grid[4] && Grid[4] == Grid[5];
            var row3 = Grid[6] == Grid[7] && Grid[7] == Grid[8];
            var col1 = Grid[0] == Grid[3] && Grid[3] == Grid[6];
            var col2 = Grid[1] == Grid[4] && Grid[4] == Grid[7];
            var col3 = Grid[2] == Grid[5] && Grid[5] == Grid[8];
            var diagDown = Grid[0] == Grid[4] && Grid[4] == Grid[8];
            var diagUp = Grid[6] == Grid[4] && Grid[4] == Grid[2];

            return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
        }
    }
}