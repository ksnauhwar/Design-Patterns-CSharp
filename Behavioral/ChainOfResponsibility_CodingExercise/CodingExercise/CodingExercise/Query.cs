using System.Linq;

namespace CodingExercise
{
    public class StatQuery
    {
        public int Result;

        public Trait Trait;

        public StatQuery(int traitValue,Trait trait)
        {
            Result = traitValue;
            Trait = trait;
        }
    }

    public enum Trait
    {
        Defense,
        Attack
    }
}