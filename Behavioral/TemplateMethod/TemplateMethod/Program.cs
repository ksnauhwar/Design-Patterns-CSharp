using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Chess(2);
            game.Run();
        }
    }
}
