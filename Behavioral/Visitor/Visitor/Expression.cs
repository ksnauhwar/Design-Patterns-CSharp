using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public abstract class Expression
    {
        public abstract void Print(StringBuilder sb);
    }

    public class DoubleExpression : Expression
    {
        private double _value;
        public DoubleExpression(double value)
        {
            _value = value;
        }
        public override void Print(StringBuilder sb)
        {
            sb.Append(_value);
        }
    }

    public class AdditionExpression : Expression
    {
        private readonly Expression _left, _right;

        public AdditionExpression(Expression left,Expression right)
        {
            _left = left;
            _right = right;
        }

        public override void Print(StringBuilder sb)
        {
            sb.Append("(");
            _left.Print(sb);
            sb.Append("+");
            _right.Print(sb);
            sb.Append(")");
        }
    }
}
