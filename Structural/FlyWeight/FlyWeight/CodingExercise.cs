using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyWeight
{
    class CodingExercise
    {
    }
}

namespace Coding.Exercise
{
    public class Sentence
    {

        private string _plainText;
        private List<WordToken> _wordTokens = new List<WordToken>();
        public Sentence(string plainText)
        {
            _plainText = plainText;
        }

        public WordToken this[int index]
        {
            get
            {
                if (_plainText.Split(' ').Length >= index)
                    _wordTokens.Add(new WordToken(index));
               return _wordTokens[_wordTokens.Count - 1];
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var textArr = _plainText.Split(' ');
            for (int i = 0; i < textArr.Length; i++)
            {
                if (i != 0)
                {
                    textArr[i] = $" {textArr[i]}";
                }
                var wordToken= _wordTokens.FirstOrDefault(wordTok => wordTok.wordIndex == i);
                if (wordToken == null || wordToken.Capitalize == false)
                {
                    sb.Append(textArr[i]);
                }
                else
                {
                    sb.Append(textArr[i].ToUpper());
                }
            }
            
            return sb.ToString();
        }

        public class WordToken
        {
            public int wordIndex;
            public bool Capitalize;

            public WordToken(int index)
            {
                wordIndex = index;
            }
        }
    }
}

