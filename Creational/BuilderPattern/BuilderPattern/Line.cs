using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace BuilderPattern
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
				var formatter = new XmlSerializer(typeof(Line));
				formatter.Serialize(ms, this);
				ms.Position = 0;
				return (Line)formatter.Deserialize(ms);
			}
		}

		public override string ToString()
		{
			return $"start {Start.X},{Start.Y} ; end {End.X},{End.Y}";
		}
	}

}

