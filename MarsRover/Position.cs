using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        //Başlangıç noktasını 0 0 N olarak kabul ediyoruz.
        public Position()
        {
            X = Y = 0;
            Direction = Directions.N;
        }

        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        private void MoveInForward()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        public void StartMoving(List<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        this.MoveInForward();
                        break;
                    case 'L':
                        this.TurnLeft();
                        break;
                    case 'R':
                        this.TurnRight();
                        break;
                    default:
                        Console.WriteLine($"Geçersiz karakter girdiniz.(Girilen değerler M,L veya R olabilir.)");
                        break;
                }

                if (this.X < 0 || this.X > maxPoints[0] || this.Y < 0 || this.Y > maxPoints[1])
                {
                    throw new Exception($"Rover pozisyonu plato sınırlarının dışında olamaz. (0 , 0) - ({maxPoints[0]} , {maxPoints[1]}) aralığında olmalıdır.");
                }
            }
        }
    }

    public interface IPosition
    {
        void StartMoving(List<int> maxPoints, string moves);
    }
}
