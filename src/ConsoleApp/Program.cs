using System;

namespace ConsoleApp
{
    class Program
    {
        public static int HeapA { get; set; }
        public static int HeapB { get; set; }
        public static int HeapC { get; set; }

        static void Main(string[] args)
        {
            var done = false;

            InitGame();
            while (!done)
            {
                DisplayInfoScreen();
                var input = GetInput();

                while (!IsValid(input))
                {
                    Console.WriteLine("\"{0}\" is invalid. Please try again", input);
                    input = GetInput();
                }
                done = true;
            }

            ConsoleUtils.WaitForEscape();
        }

        private static bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input.Length != 2)
            {
                return false;
            }

            var heap = input[0].ToString().ToUpper();

            if (heap != "A" && heap != "B" && heap != "C")
            {
                return false;
            }

            var amount = Convert.ToInt32(input[1].ToString());
            if (amount < 1 || amount > 3)
            {
                return false;
            }

            return true;
        }

        private static string GetInput()
        {
            Console.WriteLine("\nEnter a heap and an amount e.g. \"a2\" to take two from heap A.\nThe maximum amount is 3.");
            Console.Write("\n> ");
            return Console.ReadLine();
        }

        private static void InitGame()
        {
            HeapA = 3;
            HeapB = 4;
            HeapC = 5;
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
