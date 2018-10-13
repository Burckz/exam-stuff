using System;
using System.Collections.Generic;
using System.Linq;

namespace crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int green = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            string input;

            while((input = Console.ReadLine()) != "END")
            {

               if(input != "green")
                {
                    cars.Enqueue(input);
                    
                }
                else
                {
                  
                }
            }

            Console.WriteLine();
        }

        private static void Crash(string car, int passWindow)
        {
            Console.WriteLine("A crash happened!");

            Console.WriteLine($"{car} was hit at {car[car.Length - 1 - passWindow]}");
        }
    }
}
