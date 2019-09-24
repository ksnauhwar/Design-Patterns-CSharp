using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
    public class ChatRoom
    {
        private List<Person> _people;

        internal void BroadCast(string source, string message)
        {
            foreach (var person in _people)
            {
                if (string.Equals(person.Name, source, StringComparison.OrdinalIgnoreCase) == false)
                {
                    person.Receive(source,message);
                }
            }
        }

        internal void Message(string source, string destination, string message)
        {
            _people.FirstOrDefault(person => string.Equals(destination, person.Name, StringComparison.OrdinalIgnoreCase))?.Receive(source, message);
        }

        public void Join(Person person)
        {
            _people = _people ?? new List<Person>();
            person.Room = this;
            BroadCast("room", $"{person.Name} joins the room");
            _people.Add(person);
        }
    }
}