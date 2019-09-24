using System;
using System.IO;
using System.Text;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
			//Test1();
			//Test2();
			//Test3();
			Test4();

        }

		private static void Test4()
		{
			var point1 = new Line()
			{
				End = new Point()
				{
					X = 0,
					Y = 0
				},
				Start = new Point()
				{
					X=1,
					Y=1
				}
			};

			var point2 = point1.DeepCopy();
			point2.End.X = point2.End.Y = 2;
			Console.WriteLine(point1);
			Console.WriteLine(point2);
		}

		private static void Test3()
        {
            var personBuilder = new FacetedPersonBuilder();
            Person person = personBuilder.Lives
                                        .At("Road No 5")
                                        .In("Pune")
                                        .WithPostalCode("411061")
                                       .Works
                                        .At("Tavisca solution")
                                        .AsA("Tech Lead");
            Console.WriteLine(person);
        }

        private static void Test1()
        {
            var hb = new HtmlBuilder("ul");
            hb.AddChild("li", "Hello").AddChild("li", "World");
            Console.WriteLine(hb);
        }

        private static void Test2()
        {
            var person = Person.New.WorksAs("Kuldeep").WorksAs("Software Engineer").Build();
            Console.WriteLine(person);
        }
    }
}