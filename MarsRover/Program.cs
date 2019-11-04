using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input");
            Console.WriteLine("5 5");

            Console.WriteLine("1 2 N");
            RoboticRover firstRover = new RoboticRover(1, 2, Direction.N, new Plateau(5, 5));
            Console.WriteLine("LMLMLMLMM");
            firstRover.Command("LMLMLMLMM");

            Console.WriteLine("3 3 E");
            RoboticRover secondRover = new RoboticRover(3, 3, Direction.E, new Plateau(5, 5));
            Console.WriteLine("MMRMMRMRRM");
            secondRover.Command("MMRMMRMRRM");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Output");

            firstRover.GetPosition();
            secondRover.GetPosition();

            Console.ReadLine();
        }
    }
}
