using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public static class Lex
    {
        public static List<Token> GetTokens(this string expression)
        {
            var tokens = new List<Token>();
            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '(':
                        tokens.Add(new Token(Token.Type.Lparen, "("));
                        break;
                    case ')':
                        tokens.Add(new Token(Token.Type.Rparen, ")"));
                        break;
                    case '+':
                        tokens.Add(new Token(Token.Type.Addition, "+"));
                        break;
                    case '-':
                        tokens.Add(new Token(Token.Type.Subtraction, "-"));
                        break;
                    default:
                        var sb = new StringBuilder();
                        for (int j = i; j < expression.Length; j++)
                        {
                            if (char.IsDigit(expression[j]))
                            {
                                sb.Append(expression[j]);
                            }
                            else
                            {
                                i = j - 1;
                                break;
                            }
                        }
                        tokens.Add(new Token(Token.Type.Number, sb.ToString()));
                        break;
                }
            }
            return tokens;
        }
    }
}
