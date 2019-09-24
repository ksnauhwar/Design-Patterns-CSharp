using FlyWeight;
using JetBrains.dotMemoryUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UserTestFixture
{
    public class UserTest
    {
        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void UserMemoryTest()
        {
            var firstNames = Enumerable.Range(1, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(1, 100).Select(_ => RandomString());


            var users = new List<User>();
            foreach (var firstName in firstNames)
                foreach (var lastName in lastNames)
                    users.Add(new User($"{firstName} {lastName}"));
            long memoryUsed = 0;

            dotMemory.Check(memory => memoryUsed = memory.SizeInBytes);
            Assert.NotEqual(0, memoryUsed);
        }

        private string RandomString()
        {
            var rand = new Random();
            return new string(Enumerable.Range(0, 10)
                                .Select(i => (char)('a' + rand.Next(26)))
                                .ToArray());
        }
    }
}
