using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class BinaryOperation : IElement
    {
        public int Value
        {
            get
            {
                switch (OperationType)
                {
                    case Operation.Addition:
                        return LHS.Value + RHS.Value;
                    case Operation.Subtraction:
                        return LHS.Value - RHS.Value;
                    default:
                        return 0;
                }
            }
        }

        public IElement LHS, RHS;

        public enum Operation
        {
            Addition,
            Subtraction
        }

        public Operation OperationType;
    }
}
