using System;
using System.Linq;

namespace sneaking_one
{
    class Program
    {
        static void Main(string[] args)
        {
            int roomRows = int.Parse(Console.ReadLine());

            char[][] room = new char[roomRows][];

            int samRow = 0;
            int samCol = 0;

            for (int i = 0; i < roomRows; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                room[i] = new char[input.Length];

                for (int j = 0; j < input.Length; j++)
                {
                    room[i][j] = input[j];


                }

                if (room[i].Contains('S'))
                {
                    int ind = Array.IndexOf(room[i], 'S');
                    samRow = i;
                    samCol = ind;
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            if (room[samRow].Contains('b') && Array.IndexOf(room[samRow], 'b') < samCol)
            {
                room[samRow][samCol] = 'X';
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
                return;
            }
            else if (room[samRow].Contains('d') && Array.IndexOf(room[samRow], 'd') > samCol)
            {
                room[samRow][samCol] = 'X';
                Console.WriteLine($"Sam diead at {samRow}, {samCol}");
                return;
            }

            foreach (char move in directions)
            {

                EnemyMove(room);


                if (room[samRow].Contains('b') && Array.IndexOf(room[samRow], 'b') < samCol)
                {
                    room[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");
                    break;
                }
                else if (room[samRow].Contains('d') && Array.IndexOf(room[samRow], 'd') > samCol)
                {
                    room[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam diead at {samRow}, {samCol}");
                    break;
                }

                MoveSam(move, room, ref samRow, ref samCol);

                if (room[samRow].Contains('N'))
                {
                    int enemyInd = Array.IndexOf(room[samRow], 'N');

                    room[samRow][enemyInd] = 'X';

                    Console.WriteLine("Nikoladze killed!");
                    break;
                }



            }

            for (int row = 0; row < room.Length; row++)
            {
                Console.WriteLine(String.Join("", room[row]));
            }
        }

        private static void MoveSam(char move, char[][] room, ref int samRow, ref int samCol)
        {
            if (move == 'U')
            {
                room[samRow][samCol] = '.';
                samRow--;
                room[samRow][samCol] = 'S';
            }
            else if (move == 'D')
            {
                room[samRow][samCol] = '.';
                samRow++;
                room[samRow][samCol] = 'S';
            }
            else if (move == 'R')
            {
                room[samRow][samCol] = '.';
                samCol++;
                room[samRow][samCol] = 'S';
            }
            else if (move == 'L')
            {
                room[samRow][samCol] = '.';
                samCol--;
                room[samRow][samCol] = 'S';
            }
            
        }

        private static void EnemyMove(char[][] room)
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
