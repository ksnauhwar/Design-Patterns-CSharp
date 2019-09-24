using ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Proxy
{
    public class Log<T> : DynamicObject where T:class,new()
    {
        private T _subject;
        private Dictionary<string, int> _methodCall = new Dictionary<string, int>();

        public Log(T subject)
        {
            _subject = subject;
        }

        public static I As<I>() where I : class
        {
            if (typeof(I).IsInterface == false)
                throw new ArgumentException("I should be an interface");

            return new Log<T>(new T()).ActLike<I>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                Console.WriteLine($"Invoking member {_subject.GetType().Name}.{binder.Name} with arguments {string.Join(' ',args)}");
                if (_methodCall.ContainsKey(binder.Name))
                {
                    _methodCall[binder.Name] += 1;
                }
                else
                {
                    _methodCall.Add(binder.Name, 1);
                }
                result = _subject.GetType().GetMethod(binder.Name).Invoke(_subject, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public string Info()
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, int> methodInfo in _methodCall)
            {
               sb.AppendLine($"Method {methodInfo.Key} invoked {methodInfo.Value} time(s)");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Info();
        }
    }
}
