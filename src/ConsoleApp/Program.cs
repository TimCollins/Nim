using System;

namespace ConsoleApp
{
    class Program
    {
        public static GameService Game { get; set; }

        static void Main(string[] args)
        {
            Game = new GameService();
            Game.InitGame();

            var done = false;
            while (!done)
            {
                DisplayInfoScreen();
                var input = GetInput();

                while (!Game.IsValidInput(input))
                {
                    Console.WriteLine("\"{0}\" is invalid. Please try again", input);
                    input = GetInput();
                }

                Game.SaveInput(input);
                Game.ProcessInput();
                Game.UpdatePlayer();

                if (Game.AllHeapsEmpty())
                {
                    done = true;
                }
            }

            DisplayWinner();

            ConsoleUtils.WaitForEscape();
        }

        private static void DisplayWinner()
        {
            Console.WriteLine("The winner is Player {0}", Game.Player);
        }

        private static string GetInput()
        {
            Console.WriteLine("\nPlayer {0}'s turn", Game.Player);
            Console.WriteLine("Enter a heap and an amount e.g. \"a2\" to take two from heap A.\nThe maximum amount is 3.");
            Console.Write("\n> ");
            return Console.ReadLine();
        }

        private static void DisplayInfoScreen()
        {
            Console.Clear();
            Console.WriteLine("Nim Game\n--------\nBe the last to take an object!\n");
            Console.WriteLine("\nSize of heaps\nA\tB\tC");
            Console.WriteLine("{0}\t{1}\t{2}", Game.HeapA, Game.HeapB, Game.HeapC);
        }
    }
}
