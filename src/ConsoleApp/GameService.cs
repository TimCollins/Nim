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
        public int Player { get; set; }
        
        public void InitGame()
        {
            HeapA = 3;
            HeapB = 4;
            HeapC = 5;

            Player = 1;
        }

        public void InitGame(int a, int b, int c)
        {
            HeapA = a;
            HeapB = b;
            HeapC = c;

            Player = 1;
        }

        public void SaveInput(string input)
        {
            HeapInput = input[0].ToString().ToUpper();
            HeapAmount = Convert.ToInt32(input[1].ToString());
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

            var heapInput = input[0].ToString().ToUpper();

            if (heapInput != "A" && heapInput != "B" && heapInput != "C")
            {
                return false;
            }

            var heapAmount = Convert.ToInt32(input[1].ToString());
            if (heapAmount < 1 || heapAmount > 3)
            {
                return false;
            }

            if (heapInput == "A" && HeapA - heapAmount < 0)
            {
                return false;
            }

            if (heapInput == "B" && HeapB - heapAmount < 0)
            {
                return false;
            }

            if (heapInput == "C" && HeapC - heapAmount < 0)
            {
                return false;
            }

            return true;
        }

        public bool AllHeapsEmpty()
        {
            return HeapA == 0 && HeapB == 0 && HeapC == 0;
        }

        public void ProcessInput()
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
                return;
            }

            throw new ApplicationException(string.Format("Invalid HeapInput \"{0}\" specified!", HeapInput));
        }

        public void UpdatePlayer()
        {
            if (AllHeapsEmpty())
            {
                // Don't update the player if there is a winner
                return;
            }

            Player = Player == 1 ? 2 : 1;
        }
    }
}
