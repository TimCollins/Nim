using System;

namespace ConsoleApp
{
    public class GameService
    {
        public int HeapA { get; set; }
        public int HeapB { get; set; }
        public int HeapC { get; set; }
        public string HeapInput { get; set; }
        public int HeapAmount { get; set; }
        
        public void InitGame()
        {
            HeapA = 3;
            HeapB = 4;
            HeapC = 5;
        }

        public void InitGame(int a, int b, int c)
        {
            HeapA = a;
            HeapB = b;
            HeapC = c;
        }

        public bool IsValidInput(string input)
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
    }
}
