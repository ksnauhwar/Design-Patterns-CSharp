using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter
{
    public static class Parser
    {
        public static IElement Parse(IReadOnlyList<Token> tokens)
        {
            bool isLHSPresent = false;
            var binaryOperation = new BinaryOperation();
            for (int i = 0; i < tokens.Count; i++)
            {
                switch (tokens[i].TokenType)
                {
                    case Token.Type.Lparen:
                        int j = i + 1;
                        for (; j < tokens.Count; j++)
                        {
                            if (tokens[j].TokenType == Token.Type.Rparen)
                                break;
                        }
                        var subExp = tokens.Skip(i).Take(j - i - 1).ToList();
                        var element = Parse(subExp);
                        if(isLHSPresent)
                        {
                            binaryOperation.RHS = element;
                        }
                        else
                        {
                            binaryOperation.LHS = element;
                            isLHSPresent = true;
                        }
                        break;
                    case Token.Type.Addition:
                        binaryOperation.OperationType = BinaryOperation.Operation.Addition;
                        break;
                    case Token.Type.Subtraction:
                        binaryOperation.OperationType = BinaryOperation.Operation.Subtraction;
                        break; 
                    case Token.Type.Number:
                        if (isLHSPresent)
                        {
                            binaryOperation.RHS = new Integer(int.Parse(tokens[i].Text));
                        }
                        else
                        {
                            binaryOperation.LHS = new Integer(int.Parse(tokens[i].Text));
                            isLHSPresent = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            return binaryOperation;
        }
    }
}
