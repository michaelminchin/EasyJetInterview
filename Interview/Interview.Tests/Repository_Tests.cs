using System;
using NUnit.Framework;
using Moq;
using Interview;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Interview.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void StringRepository_SaveStorable_SetsCountToOne()
        {
            // Arrange
            ILogger logger = new Logger();
            Storeable<string> storeable = new Storeable<string> { Id = "first" };
            ICollection<IStoreable<string>> storeableCollection = new Collection<IStoreable<string>>();
            Repository<IStoreable<string>, string> stringRepository = new Repository<IStoreable<string>, string>(storeableCollection, logger);

            // Act
            stringRepository.Save(storeable);

            // Assert
            Assert.That(storeableCollection.Count == 1);
        }
    }
}
