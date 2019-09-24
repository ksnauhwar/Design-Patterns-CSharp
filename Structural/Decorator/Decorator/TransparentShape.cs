using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class TransparentShape : IShape
    {
        IShape Shape;
        public string  Transparency { get; set; }

        public TransparentShape(IShape shape,string transparency)
        {
            Shape = shape;
            Transparency = transparency;
        }
        public string AsString()
        {
            return $"{Shape.AsString()} with transparency {Transparency}%";
        }
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        public int Transparency { get; set; }
        T shape = new T();
        public TransparentShape():this(10)
        {

        }
        public TransparentShape(int transparency)
        {
            Transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} with transparency of {Transparency}";
        
    }
}
