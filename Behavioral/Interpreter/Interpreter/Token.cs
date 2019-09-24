using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class Token
    {
       public enum Type
        {
            Rparen,
            Lparen,
            Addition,
            Subtraction,
            Number
        }

        public Type TokenType { get; set; }

        public string Text { get; set; }

        public Token(Type tokenType,string text)
        {
            TokenType = tokenType;
            Text = text;
        }
    }
}
