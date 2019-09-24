using System;
using System.Collections.Generic;
using System.Text;

//Assuming the entire expression heirarchy already exists and we need to add Print functionality 
namespace Visitor
{
    using DicType = Dictionary<Type, Action<NewExpression, StringBuilder>>;
           
    public abstract class NewExpression
    {
        
    }

    public class NewDoubleExpression : NewExpression
    {
        public double Value;

        public NewDoubleExpression(double value)
        {
            Value = value;
        }
    }

    public class NewAdditionExpression : NewExpression
    {
        public readonly NewExpression Left, Right;

        public NewAdditionExpression(NewExpression left, NewExpression right)
        {
            Left = left;
            Right = right;
        }
    }

    
    public static class ExpressionPrinter
    {
        public static DicType dic = new DicType()
        {
            [typeof(NewDoubleExpression)] = (e, sb) =>
            {
                var de = e as NewDoubleExpression;
                sb.Append(de.Value);
            },
            [typeof(NewAdditionExpression)] = (e, sb) => 
            {
                var ae = e as NewAdditionExpression;
                sb.Append("(");
                ae.Left.Print(sb);
                sb.Append("+");
                ae.Right.Print(sb);
                sb.Append(")");
            }
        };
        public static void Print(this NewExpression exp, StringBuilder sb)
        {
            dic[exp.GetType()](exp, sb);//New Syntax for invoking an action
        }


        //public static void Print(this NewExpression exp, StringBuilder sb)
        //{
        //    if (exp is NewDoubleExpression de)
        //    {
        //        sb.Append(de.Value);
        //    }
        //    else if (exp is NewAdditionExpression ae)
        //    {
        //        sb.Append("(");
        //        ae.Left.Print(sb);
        //        sb.Append("+");
        //        ae.Right.Print(sb);
        //        sb.Append(")");
        //    }
        //}

    }

    public static class DynamicExpressionPrinter
    {
        public static void Print(NewAdditionExpression ae, StringBuilder sb)
        {
            sb.Append("(");
            Print((dynamic)ae.Left, sb);
            sb.Append("+");
            Print((dynamic)ae.Right, sb);
            sb.Append(")");
        }

        public static void Print(NewDoubleExpression de, StringBuilder sb)
        {
            sb.Append(de.Value);
        }
    }
}
