using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            Test2();
        }

        private static void Test2()
        {
            ColouredShape<Square> colouredShape = new ColouredShape<Square>();
            Console.WriteLine(colouredShape.AsString());

            TransparentShape<ColouredShape<Square>> transparentShape = new TransparentShape<ColouredShape<Square>>();
            Console.WriteLine(transparentShape.AsString());
        }

        private static void Test1()
        {
            var square = new Square(5);
            Console.WriteLine(square.AsString());

            //var colouredSquare = new ColouredShape(square, "red");
            //Console.WriteLine(colouredSquare.AsString());

            //var transparentShape = new TransparentShape(colouredSquare, "50");
            //Console.WriteLine(transparentShape.AsString());
        }
    }
}
