using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    public class CodingExercise
    {
       

    }

    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square Square;

        public SquareToRectangleAdapter(Square square)
        {
            Square = new Square()
            {
                Side = square.Side
            };
        }

        public int Width => Square.Side;

        public int Height =>Square.Side;
        
    }
}
