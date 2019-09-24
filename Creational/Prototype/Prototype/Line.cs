using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Prototype
{
    public class Point
    {
      public int X, Y;
    }
    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(Line));
                serializer.Serialize(ms,this);
                ms.Position = 0;
                return (Line)serializer.Deserialize(ms);
            }
        }

        public override string ToString()
        {
            return $"start {Start.X},{Start.Y} ; end {End.X},{End.Y}";
        }
    }
}
