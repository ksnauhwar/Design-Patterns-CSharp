using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class HtmlBuilder
    {
        private HtmlElement _rootElement = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            _rootElement.Name = rootName;
        }

        public HtmlBuilder AddChild(string name, string text)
        {
            var htmlElement = new HtmlElement(name,text);
            _rootElement.HtmlElements.Add(htmlElement);
            return this;
        }

        public override string ToString()
        {
            return _rootElement.ToString();
        }
    }
}
