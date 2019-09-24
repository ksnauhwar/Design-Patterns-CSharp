using Autofac;
using System;
using System.Linq;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            Test2();

        }

        private static void Test2()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<EventBroker.Mediator.EventBroker>().SingleInstance();
            cb.RegisterType<EventBroker.Mediator.FootballCoach>();
            cb.Register((c, p) => new EventBroker.Mediator.FootballPlayer(c.Resolve<EventBroker.Mediator.EventBroker>(),
                p.Named<string>("name")));

            using (var c = cb.Build())
            {
                var coach = c.Resolve<EventBroker.Mediator.FootballCoach>();
                var player1 = c.Resolve<EventBroker.Mediator.FootballPlayer>(new NamedParameter("name", "John"));
                var player2 = c.Resolve<EventBroker.Mediator.FootballPlayer>(new NamedParameter("name", "Jane"));
                player1.Score();
                player1.Score();
                player1.Score();
                player1.KickRef();
                player2.Score();

            }
        }

        private static void Test1()
        {
            var room = new ChatRoom();
            var kane = new Person("Kane");
            var abel = new Person("Abel");
            room.Join(kane);
            room.Join(abel);
            kane.Say("hi");
            abel.Say("hello");
            var simon = new Person("simon");
            room.Join(simon);
            simon.Say("Hello everyone");
            kane.PrivateMessage("Simon", "Glad you joined Simon!");
            Console.WriteLine(string.Join("\n", kane.ChatLog.Select(log => log)));
            Console.WriteLine(string.Join("\n", abel.ChatLog.Select(log => log)));
            Console.WriteLine(string.Join("\n", simon.ChatLog.Select(log => log)));
        }
    }
}
