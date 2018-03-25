using System;
using System.Collections.Generic;
using System.Text;

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

        private Random _rand;
        
        public void InitGame()
        {
            CommonInit(3, 4, 5);
        }

        public void InitGame(int a, int b, int c)
        {
            CommonInit(a, b, c);
        }

        private void CommonInit(int a, int b, int c)
        {
            HeapA = a;
            HeapB = b;
            HeapC = c;

            Player = 1;
            _rand = new Random();
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

            if (input.ToLower() == "quit")
            {
                return true;
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

        public string GetRandomInput()
        {
            // The computer player will simply choose a random heap and 
            // a random valid amount
            var output = new StringBuilder();

            // Find available non-zero heaps
            output.Append(GetRandomHeap());
            output.Append(GetRandomAmount(output));

            return output.ToString();
        }

        private int GetRandomAmount(StringBuilder output)
        {
            int max;
            var tmp = output.ToString();
            if (tmp == "a")
            {
                max = HeapA;
            }
            else if (tmp == "b")
            {
                max = HeapB;
            }
            else
            {
                max = HeapC;
            }

            // Upper bound is exclusive
            if (max > 4)
            {
                max = 4;
            }
            var amount = _rand.Next(1, max);
            return amount;
        }

        private string GetRandomHeap()
        {
            var heaps = new List<string>();
            if (HeapA > 0)
            {
                heaps.Add("a");
            }

            if (HeapB > 0)
            {
                heaps.Add("b");
            }

            if (HeapC > 0)
            {
                heaps.Add("c");
            }

            var count = heaps.Count;
            if (count == 1)
            {
                return heaps[0];
            }

            var v = _rand.Next(1, count);
            return heaps[v];
        }
    }
}
