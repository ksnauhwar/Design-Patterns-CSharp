using System;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var exp = "(12+2)-(11+2)";
            var tokens = exp.GetTokens();
        }

    }
}
