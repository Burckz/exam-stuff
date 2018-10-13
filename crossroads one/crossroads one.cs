using System;
using System.Collections.Generic;

namespace crossroads_one
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());

            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string input = Console.ReadLine();

            int passedCars = 0;

            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                if(cars.Count == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                string car = cars.Dequeue();
                string currentCar = car;
                int currentLight = greenLight;

                

                while(currentLight > 0)
                {
                    car = car.Remove(0, 1);
                    currentLight--;
                    if(car.Length == 0)
                    {
                        passedCars++;
                        if(cars.Count > 0 && currentLight > 0)
                        {
                        car = cars.Dequeue();

                        currentCar = car;
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                }

                if(currentLight >= 0 && car.Length == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    currentLight += freeWindow;

                    while(currentLight > 0)
                    {
                        if(car.Length > 0)
                        {
                        car = car.Remove(0, 1);

                        }
                        else
                        {
                            break;
                        }
                        currentLight--;
                        if(car.Length == 0)
                        {
                            passedCars++;
                        }
                        
                    }
                }

                if(currentLight == 0 && car.Length > 0)
                {
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currentCar} was hit at {car[0]}.");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
