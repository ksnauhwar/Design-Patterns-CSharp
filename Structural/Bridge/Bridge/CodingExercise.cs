using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer
    {
        //public string WhatToRenderAs => "Drawing {0} as lines";
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        //Depends on a arguemnt
        //public string WhatToRenderAs => "Drawing {0} as pixels";
        public string WhatToRenderAs => "pixels";
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }

        //public override string ToString()
        //{
        //    return string.Format(renderer.WhatToRenderAs, Name);
        //}
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer):base(renderer)
        {
            Name = "Square";
        }

        //public override string ToString()
        //{
        //    return string.Format(renderer.WhatToRenderAs,Name);
        //}
    }
}
