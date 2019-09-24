using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            var game = new BrokerChain.Game();
            var creature = new BrokerChain.Creature(game,3,3,"Goblin");
            //Console.WriteLine(creature);
            using (var attackDoubler = new BrokerChain.AttackModifier(creature,game ))
            {
                Console.WriteLine(creature);
            }
                Console.WriteLine(creature);
        }

        private static void Test1()
        {
            var creature = new Creature();
            var cm = new CreatureModifier(creature);
            cm.Add(new AttackModifier(creature));
            cm.Handle();
            Console.WriteLine("Hello World!");
        }
    }
}
