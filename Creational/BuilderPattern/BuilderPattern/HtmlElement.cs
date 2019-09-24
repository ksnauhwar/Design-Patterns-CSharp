using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class HtmlElement
    {
        private int _indentSize = 2;

        public List<HtmlElement> HtmlElements = new List<HtmlElement>();

        public string Name { get; set; }
        public string Text { get; set; }

        public HtmlElement()
        {

        }

        public HtmlElement(string name,string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var indentSpace = new string(' ', indent * _indentSize);
            sb.AppendLine($"{indentSpace}<{Name}>");

            if (string.IsNullOrEmpty(Text) == false)
            {
                indent += 1;
                sb.AppendLine($"{new string(' ',indent*_indentSize)}{Text}");
            }

            //Check the code stack
            HtmlElements.ForEach(htmlElement => sb.AppendLine(htmlElement.ToStringImpl(indent + 1)));


            sb.AppendFormat($"{indentSpace}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

}
