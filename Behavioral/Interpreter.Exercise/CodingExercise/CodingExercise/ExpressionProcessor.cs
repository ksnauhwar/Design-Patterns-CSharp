using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise
{
    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            var tokens = expression.GetTokens();

            var variableTokens = tokens.FindAll(token => token.TokenType == Token.Type.Variable);

            if (tokens.Exists(token => token.TokenType == Token.Type.Variable && token.Text.Length>1)
                || IsVariableInvalid(variableTokens))
            return 0;

            ReplaceVariablesWithNumbers(variableTokens);

            return Parser.ParseTokens(tokens);

        }

        private void ReplaceVariablesWithNumbers(List<Token> variableTokens)
        {
            for (int i = 0; i < variableTokens.Count; i++)
            {
                variableTokens[i].Text = Variables[variableTokens[i].Text[0]].ToString();
                variableTokens[i].TokenType = Token.Type.Number;
            }
        }

        private bool IsVariableInvalid(List<Token> variableTokens)
        {
            if (variableTokens.Count == 0)
                return false;

            return variableTokens.Exists(token => Variables.ContainsKey(token.Text[0]) == false);
        }
    }
}
