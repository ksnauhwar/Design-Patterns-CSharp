using System;

namespace CodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var exp = "10-2-x";
            
            var expProcessor =new ExpressionProcessor();
            expProcessor.Variables['x'] = 3; 
            var result = expProcessor.Calculate(exp);
        }
    }
}
