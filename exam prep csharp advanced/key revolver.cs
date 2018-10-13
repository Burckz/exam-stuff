using System;
using System.Collections.Generic;
using System.Linq;

namespace exam_prep_csharp_advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int intelligence = int.Parse(Console.ReadLine());
            

            int counter = 0;

            int bulletsShot = 0;

            while (true)
            {
                int bullet = bullets.Pop();
                int lockk = locks.Peek();
                bulletsShot++;

                counter++;

                if(bullet <= lockk)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if(counter == gunBarrelSize && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }

                if(locks.Count == 0 )
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (bulletsShot * bulletPrice)}");
                    break;
                }

                if(bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }

            }

        }

       
    }
}
