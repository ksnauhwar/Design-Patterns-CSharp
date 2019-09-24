using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class Square : /*IShape*/Shape
    {
        public int Side { get; set; }

        public Square():this(1)
        {

        }

        public Square(int side)
        {
            Side = side;
        }
        //public string AsString()
        //{
        //    return $"Square of side {Side}";
        //}

        public override string AsString() => $"Square of size {Side}";
        
    }
}
