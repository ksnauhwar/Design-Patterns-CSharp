using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise
{
    public class Token
    {
        public enum Type
        {
            Addition,
            Subtraction,
            Number,
            Variable
        }

        public Type TokenType;
        public string Text;

        public Token(Type tokenType,string text)
        {
            TokenType = tokenType;
            Text = text;
        }
    }
}
