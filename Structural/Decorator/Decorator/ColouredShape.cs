using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class ColouredShape : IShape
    {
        IShape Shape;
        public string Colour { get; set; }

        public ColouredShape(IShape shape,string colour)
        {
            Shape = shape;
            Colour = colour;
        }
        public string AsString()
        {
            return $"{Shape.AsString()} of colour {Colour}";
        }
    }

    public class ColouredShape<T> : Shape where T : Shape, new()
    {
        public string Colour { get; set; }
        T shape = new T();

        public ColouredShape():this("red")
        {

        }

        public ColouredShape(string colour)
        {
            Colour = colour;
        }

        public override string AsString() => $"{shape.AsString()} of colour {Colour}";
        
    }
}
