using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public class AcyclicVisitor
    {
        public interface IVisitor<TVisitable> where TVisitable : class
        {
            void Visit(TVisitable obj);
        }

        public interface IVisitor // Marker Interface
        {

        }

        public abstract class Expression
        {
            public virtual void Accept(IVisitor visitor)
            {
                if (visitor is IVisitor<Expression> ie)
                {
                    ie.Visit(this);
                }
            }
        }


        public class DoubleExpression : Expression
        {
            public double Value;

            public DoubleExpression(double value)
            {
                Value = value;
            }

            public override void Accept(IVisitor visitor)
            {
                //what will happen if we do not add this check
                if (visitor is IVisitor<DoubleExpression> de)
                {
                    de.Visit(this);
                }
            }
        }

        public class AdditionExpression : Expression
        {
            public Expression Left, Right;

            public AdditionExpression(Expression left,Expression right)
            {
                Left = left;
                Right = right;
            }

            public override void Accept(IVisitor visitor)
            {
                if (visitor is IVisitor<AdditionExpression> ae)
                {
                    ae.Visit(this);
                }
            }
        }

        public class ExpressionPrinter : IVisitor, IVisitor<DoubleExpression>,IVisitor<AdditionExpression>
        {
            private StringBuilder _sb = new StringBuilder();

            public void Visit(DoubleExpression obj)
            {
                _sb.Append(obj.Value);
            }

            public void Visit(AdditionExpression obj)
            {
                _sb.Append("(");
                obj.Left.Accept(this);
                _sb.Append("+");
                obj.Right.Accept(this);
                _sb.Append(")");
            }

            public override string ToString() => _sb.ToString();
        }


    }
}
