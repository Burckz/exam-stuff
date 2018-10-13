using System;

namespace knight_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            

            string[,] board = new string[size, size];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for(int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col].ToString();
                   
                }
                
            }

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            int counterKnights = 0;

            

            for(int row = 0; row < board.GetLength(0); row++)
            {
                for(int col = 0; col < board.GetLength(1); col++)
                {
                    

                    if(board[row,col] == "K")
                    {
                        Check(board, board[row,col], counterKnights, row, col);
                    }


                }
            }

            Console.WriteLine(counterKnights);
        }

        private static void Check(string[,] board, string v, int counterKnights, int row, int col)
        {
            string knight = board[row, col];

            
        }
    }
}
