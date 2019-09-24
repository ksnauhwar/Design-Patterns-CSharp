using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    public class AttackModifier: CreatureModifier
    {
        public AttackModifier(Creature creature) : base(creature)
        {

        }

        public override void Handle()
        {
            Console.WriteLine($"Increasing attack");
            base.Handle();  
        }
    }
}
