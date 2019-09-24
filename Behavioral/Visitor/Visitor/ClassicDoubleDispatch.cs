﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
   public class ClassicDoubleDispatch
    {
        public interface IExpressionVisitor
        {
            void Visit(DoubleExpression de);
            void Visit(AdditionExpression ae);
        }

        public abstract class Expression
        {
            public abstract void Accept(IExpressionVisitor visitor);
        }

        public class DoubleExpression : Expression
        {
            public double Value;

            public DoubleExpression(double value)
            {
                Value = value;
            }

            public override void Accept(IExpressionVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class AdditionExpression : Expression
        {
            public readonly Expression Left, Right;

            public AdditionExpression(Expression left, Expression right)
            {
                Left = left;
                Right = right;
            }

            public override void Accept(IExpressionVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class ExpressionPrinter : IExpressionVisitor
        {
            private StringBuilder sb = new StringBuilder();

            public void Visit(DoubleExpression de)
            {
                sb.Append(de.Value);
            }

            public void Visit(AdditionExpression ae)
            {
                sb.Append("(");
                ae.Left.Accept(this); 
                sb.Append("+");
                ae.Right.Accept(this);
                sb.Append(")");
            }

            public override string ToString()
            {
                return sb.ToString();
            }
        }

        public class ExpressionCalculator : IExpressionVisitor
        {
            public double Result;

            public void Visit(DoubleExpression de)
            {
                Result = de.Value;
            }

            public void Visit(AdditionExpression ae)
            {
                ae.Left.Accept(this);
                var a = Result;
                ae.Right.Accept(this);
                var b = Result;
                Result = a + b;
            }
        }

    }
}
