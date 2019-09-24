using ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace NullObject
{
    public class Null<I> : DynamicObject where I:class
    {
        public static I Instance { get => new Null<I>().ActLike<I>(); }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }
}
