using System;
using System.Text;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();

            //Test2();

            //Test3();


            //Test4();

            Test5();

        }

        private static void Test5()
        {
            var additionExpression = new AcyclicVisitor.AdditionExpression(new AcyclicVisitor.DoubleExpression(1),
                                                  new AcyclicVisitor.AdditionExpression(new AcyclicVisitor.DoubleExpression(2),
                                                                         new AcyclicVisitor.DoubleExpression(3)));

            var ep = new AcyclicVisitor.ExpressionPrinter();
            ep.Visit(additionExpression);
            Console.WriteLine(ep);
        }

        private static void Test4()
        {
            NewExpression additionalExpression = new NewAdditionExpression(new NewDoubleExpression(1),
                            new NewAdditionExpression(new NewDoubleExpression(2),
                                                   new NewDoubleExpression(3)));
            var sb = new StringBuilder();
            DynamicExpressionPrinter.Print((dynamic)additionalExpression, sb);
            Console.WriteLine(sb);
        }

        private static void Test3()
        {
            var additionExpression = new ClassicDoubleDispatch.AdditionExpression(new ClassicDoubleDispatch.DoubleExpression(1),
                                       new ClassicDoubleDispatch.AdditionExpression(new ClassicDoubleDispatch.DoubleExpression(2),
                                                              new ClassicDoubleDispatch.DoubleExpression(3)));

            var ep = new ClassicDoubleDispatch.ExpressionPrinter();
            ep.Visit(additionExpression);
            Console.WriteLine(ep);

            var expressionCalculator = new ClassicDoubleDispatch.ExpressionCalculator();
            expressionCalculator.Visit(additionExpression);
            Console.WriteLine($"{ep} = {expressionCalculator.Result}");
        }

        private static void Test2()
        {
            var additionalExpression = new NewAdditionExpression(new NewDoubleExpression(1),
                            new NewAdditionExpression(new NewDoubleExpression(2),
                                                   new NewDoubleExpression(3)));
            var sb = new StringBuilder();
            additionalExpression.Print(sb);
            Console.WriteLine(sb);
        }

        private static void Test1()
        {
            var additionExpression = new AdditionExpression(new DoubleExpression(1),
                new AdditionExpression(new DoubleExpression(2),
                                       new DoubleExpression(3)));
            var sb = new StringBuilder();
            additionExpression.Print(sb);
            Console.WriteLine(sb);
        }
    }
}
