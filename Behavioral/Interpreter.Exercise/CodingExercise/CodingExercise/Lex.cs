using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise
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
                    case '+':
                        tokens.Add(new Token(Token.Type.Addition, ""));
                        break;
                    case '-':
                        tokens.Add(new Token(Token.Type.Subtraction, ""));
                        break;
                    default:
                        var sb = new StringBuilder();
                        var isNumber = char.IsDigit(expression[i]);
                        int j = i;
                        for (; j < expression.Length; j++)
                        {
                            if (isNumber)
                            {
                                if (char.IsDigit(expression[j]))
                                {
                                    sb.Append(expression[j]);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (char.IsDigit(expression[j]) == false)
                                {
                                    sb.Append(expression[j]);
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        i = j - 1;
                        tokens.Add(new Token(isNumber ? Token.Type.Number : Token.Type.Variable, sb.ToString()));
                        break;
                }
            }
            return tokens;
        }
    }
}
