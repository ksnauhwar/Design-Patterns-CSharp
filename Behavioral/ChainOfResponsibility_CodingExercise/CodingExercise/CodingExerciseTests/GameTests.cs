using CodingExercise;
using System;
using Xunit;

namespace CodingExerciseTests
{
    public class GameTests
    {
        [Fact]
        public void GoblinCreationTest()
        {
            var game = new Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);
            Assert.Equal(1, goblin.Attack);
            Assert.Equal(1, goblin.Defense);
        }

        [Fact]
        public void GoblinDefenceTest()
        {
            var game = new Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);
            Assert.Equal(1, goblin.Defense);
            var otherGoblin = new Goblin(game);
            game.Creatures.Add(otherGoblin);
            Assert.Equal(2,goblin.Defense);
            Assert.Equal(2, otherGoblin.Defense);
        }


        [Fact]
        public void GoblinAttackTest()
        {
            var game = new Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);
            Assert.Equal(1, goblin.Attack);
            var otherGoblin = new Goblin(game);
            game.Creatures.Add(otherGoblin);
            Assert.Equal(1, goblin.Attack);
            Assert.Equal(1, otherGoblin.Attack);

            var goblinKing = new GoblinKing(game);
            game.Creatures.Add(goblinKing);
            Assert.Equal(2, goblin.Attack);
            Assert.Equal(2, otherGoblin.Attack);
        }


    }
}
