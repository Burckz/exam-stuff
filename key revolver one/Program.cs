using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace key_revolver_one
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());

            int[] bulletArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(bulletArr);

            int[] locksArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(locksArr);

            int price = int.Parse(Console.ReadLine());

            int barrel = 0;
            int shots = 0;

            while(bullets.Count > 0)
            {
                int bullet = bullets.Pop();
                int lockTarget = locks.Peek();
                barrel++;
                shots++;

                if(bullet <= lockTarget)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if(barrel == gunBarrel && bullets.Count > 0)
                {
                    barrel = 0;
                    Console.WriteLine("Reloading!");
                }

                if(locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${price - (priceBullet * shots)}");
                    return;
                }

            }

            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
