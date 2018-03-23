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

            HeapInput = input[0].ToString().ToUpper();

            if (HeapInput != "A" && HeapInput != "B" && HeapInput != "C")
            {
                return false;
            }

            HeapAmount = Convert.ToInt32(input[1].ToString());
            if (HeapAmount < 1 || HeapAmount > 3)
            {
                return false;
            }

            if (HeapInput == "A" && HeapA - HeapAmount < 0)
            {
                return false;
            }

            if (HeapInput == "B" && HeapB - HeapAmount < 0)
            {
                return false;
            }

            if (HeapInput == "C" && HeapC - HeapAmount < 0)
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
