using Coding.Exercise;
using System;
using Xunit;

namespace RatUnitTests
{
    public class RatTests
    {
        [Fact]
        public void SingleRatTest()
        {
            var game = new Game();
            var rat = new Rat(game);
            Assert.Equal(1,rat.Attack);
        }

        [Fact]
        public void TwoRatTest()
        {
            var game = new Game();
            var rat = new Rat(game);
            var rat2 = new Rat(game);
            Assert.Equal(2,rat.Attack);
            Assert.Equal(2,rat2.Attack);
        }

        [Fact]
        public void ThreeRatsOneDies()
        {
            var game = new Game();

            var rat = new Rat(game);
            Assert.Equal(1,rat.Attack);

            var rat2 = new Rat(game);
            Assert.Equal(2,rat.Attack);
            Assert.Equal(2,rat2.Attack);

            using (var rat3 = new Rat(game))
            {
                Assert.Equal(3,rat.Attack);
                Assert.Equal(3,rat2.Attack);
                Assert.Equal(3,rat3.Attack);
            }

            Assert.Equal(2,rat.Attack);
            Assert.Equal(2,rat2.Attack);
        }
    }
}

