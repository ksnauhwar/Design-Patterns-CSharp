﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    class CodingExercise
    {
    }
    public interface IValueContainer:IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethod
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }
}
