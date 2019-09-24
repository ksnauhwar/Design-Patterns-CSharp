using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public enum LockState
    {
        Locked,
        UnLocked,
        Failed
    }

    public class SwitchBasedState
    {
        private string _unlockCode = "1234";
        public LockState Current { get; set; }

        public StringBuilder CodeEntered = new StringBuilder();

        public SwitchBasedState()
        {
            Current = LockState.Locked;
        }


        public LockState BeginStateTransition()
        {
            switch (Current)
            {
                case LockState.Locked:
                    CodeEntered.Append(Console.ReadKey().KeyChar);
                    if (string.Equals(CodeEntered.ToString(), _unlockCode))
                    {
                        Current = LockState.UnLocked;
                        break;
                    }
                    else if(_unlockCode.StartsWith(CodeEntered.ToString() ) == false)
                    {
                        Current = LockState.Failed;
                    }

                    break;
                case LockState.UnLocked:
                    Console.CursorLeft = 0;
                    Console.WriteLine("UNLOCKED");
                    break;
                case LockState.Failed:
                    Console.CursorLeft = 0;
                    Console.WriteLine("FAILED");
                    Current = LockState.Locked;
                    CodeEntered.Clear();
                    break;
            }

            return Current;
        }

    }
}

