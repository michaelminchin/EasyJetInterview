using System;
using NUnit.Framework;

namespace Interview.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void StringRepository_SaveStorable_SetsCountToOne()
        {
            // Arrange
            Repository<IStorable<string>, string> stringRepository = new Repository<IStorable<string>, string>();


            // Act

            // Assert

        }
    }
}
