using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen platonun sağ üst köşe koordinatlarını girin.(Örn: 5 5)");

            //plateuCoordinates almasının sebebi platonun yüzeyini kontrolunun sağlanması içindir.
            //platonun sınırlarının dışına çıkılırsa uyarı verilecektir.
            var plateuCoordinates = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            Console.WriteLine("Lütfen 1.Rover pozisyonu giriniz.(Örn: 1 2 N)");
            var startPositions = Console.ReadLine().Trim().Split(' ');

            Position position = new Position();

            if (startPositions.Count() == 3)
            {
                position.X = Convert.ToInt32(startPositions[0]);
                position.Y = Convert.ToInt32(startPositions[1]);
                position.Direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2]);
            }
            else
            {
                Console.WriteLine("Lütfen doğru formatta girin.(Örn: 1 2 N)");
            }

            Console.WriteLine("Lütfen 1.Rover hareket talimatlarını girin.(Örn: LMLMLMLMM)");

            var moves = Console.ReadLine().ToUpper();

            try
            {
                position.StartMoving(plateuCoordinates, moves);
                Console.WriteLine($"1.Rover Varış Noktası : {position.X} {position.Y} {position.Direction.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //second

            Console.WriteLine("Lütfen 2.Rover pozisyonu giriniz.(Örn: 3 3 E)");
            var ssecondStartPositions = Console.ReadLine().Trim().Split(' ');

            Position secondPosition = new Position();

            if (ssecondStartPositions.Count() == 3)
            {
                secondPosition.X = Convert.ToInt32(ssecondStartPositions[0]);
                secondPosition.Y = Convert.ToInt32(ssecondStartPositions[1]);
                secondPosition.Direction = (Directions)Enum.Parse(typeof(Directions), ssecondStartPositions[2]);
            }
            else
            {
                Console.WriteLine("Lütfen doğru formatta girin.(Örn: 1 2 N)");
            }

            Console.WriteLine("Lütfen 2.Rover hareket talimatlarını girin.(Örn: MMRMMRMRRM)");

            var secondMoves = Console.ReadLine().ToUpper();

            try
            {
                secondPosition.StartMoving(plateuCoordinates, secondMoves);
                Console.WriteLine($"2.Rover Varış Noktası : {secondPosition.X} {secondPosition.Y} {secondPosition.Direction.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
