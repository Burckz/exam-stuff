using System;
using System.Linq;

namespace sneaking
{
    class sneaking
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] room = new char[rows][];

            int samRow = 0;
            int samCol = 0;

            for(int row = 0; row < room.Length; row++)
            {
                char[] column = Console.ReadLine().ToCharArray();

                room[row] = new char[column.Length];

                for (int col = 0; col < column.Length; col++)
                {
                    room[row][col] = column[col];

                    if(room[row][col] == 'S')
                    {
                        samCol = col;
                        samRow = row;
                    }
                }
            }

            char[] direction = Console.ReadLine().ToCharArray();

            foreach(char dir in direction)
            {
                MoveEnemies(room);

                if(room[samRow].Contains('b') && Array.IndexOf(room[samRow], 'b') < samCol)
                {
                    room[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow},{samCol}");
                    break;
                }
                else if(room[samRow].Contains('d') && Array.IndexOf(room[samRow], 'd') > samCol)
                {
                    room[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam diead at {samRow},{samCol}");
                    break;
                }

                MoveSam(room, ref samRow, ref samCol, dir);

                if (room[samRow].Contains('N'))
                {
                    int nIndex = Array.IndexOf(room[samRow], 'N');

                    room[samRow][nIndex] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            for( int row = 0; row < room.Length; row++)
            {
                for(int col = 0; col < room[row].Length; col++)
                {
                    Console.Write($"{room[row][col]}");
                }
                Console.WriteLine();
            }
        }

        private static void MoveSam(char[][] room, ref int samRow, ref int samCol, char dir)
        {
            if (dir == 'U')
            {
                room[samRow][samCol] = '.';
                samRow--;
                room[samRow][samCol] = 'S';

            }
            else if (dir == 'D')
            {
                room[samRow][samCol] = '.';
                samRow++;
                room[samRow][samCol] = 'S';
            }
            else if (dir == 'R')
            {
                room[samRow][samCol] = '.';
                samCol++;
                room[samRow][samCol] = 'S';
            }
            else if (dir == 'L')
            {
                room[samRow][samCol] = '.';
                samCol--;
                room[samRow][samCol] = 'S';
            }
            else if (dir == 'W') 
            {
                return;
            }
        }

        private static void MoveEnemies(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {


                for (int col = 0; col < room[row].Length; col++)
                {
                    char position = room[row][col];

                    if (position == 'b')
                    {
                        if (col == room[row].Length - 1)
                        {
                            room[row][col] = 'd';
                            break;
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = position;
                            break;
                        }
                    }

                    if (position == 'd')
                    {
                        if (col == 0)
                        {
                            room[row][col] = 'b';
                            break;
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = position;
                            break;
                        }
                    }
                }
            }
        }
    }
}
