using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    public class Person
    {
        public readonly string Name;
        public List<string> ChatLog { get; set; }
        public Person(string name)
        {
            Name = name;
            ChatLog = new List<string>();
        }

        public ChatRoom Room { get; set; }

        public void Say(string message)
        {
            Room.BroadCast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }

        public void Receive(string source,string message)
        {
            ChatLog.Add($"[{Name}'s chat log] {source} : {message}");
        }
    }
}
