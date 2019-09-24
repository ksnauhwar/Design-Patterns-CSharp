using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise
{
    public static class Parser
    {
        public static int ParseTokens(IReadOnlyList<Token> tokens)
        {
            int result = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                switch (tokens[i].TokenType)
                {
                    case Token.Type.Addition:
                        result += int.Parse(tokens[i+1].Text);
                        i++;
                        break;
                    case Token.Type.Subtraction:
                        result -= int.Parse(tokens[i + 1].Text);
                        i++;
                        break;
                    case Token.Type.Number:
                        result += int.Parse(tokens[i].Text);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
