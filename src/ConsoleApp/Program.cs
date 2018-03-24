using System;

namespace ConsoleApp
{
    class Program
    {
        public static int HeapA { get; set; }
        public static int HeapB { get; set; }
        public static int HeapC { get; set; }
        public static string HeapInput { get; set; }
        public static int HeapAmount { get; set; }

        static void Main(string[] args)
        {
            var game = new GameService();
            game.InitGame();

            var done = false;
            while (!done)
            {
                DisplayInfoScreen();
                var input = GetInput();

                while (!game.IsValidInput(input))
                {
                    Console.WriteLine("\"{0}\" is invalid. Please try again", input);
                    input = GetInput();
                }

                ProcessInput();

                if (AllHeapsEmpty())
                {
                    done = true;
                }
            }

            ConsoleUtils.WaitForEscape();
        }

        private static bool AllHeapsEmpty()
        {
            return HeapA == 0 && HeapB == 0 && HeapC == 0;
        }

        private static void ProcessInput()
        {
            if (HeapInput == "A")
            {
                HeapA -= HeapAmount;
                return;
            }

            if (HeapInput == "B")
            {
                HeapB -= HeapAmount;
                return;
            }

            if (HeapInput == "C")
            {
                HeapC -= HeapAmount;
            }
        }

        private static string GetInput()
        {
            Console.WriteLine("\nEnter a heap and an amount e.g. \"a2\" to take two from heap A.\nThe maximum amount is 3.");
            Console.Write("\n> ");
            return Console.ReadLine();
        }

        private static void DisplayInfoScreen()
        {
            Console.Clear();
            Console.WriteLine("Nim Game\n--------\nBe the last to take an object!\n");
            Console.WriteLine("\nSize of heaps\nA\tB\tC");
            Console.WriteLine("{0}\t{1}\t{2}", HeapA, HeapB, HeapC);
        }
    }
}
