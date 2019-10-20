using System;
using NUnit.Framework;
using Moq;
using Interview;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Interview.Tests
{

    [TestFixture]
    public class Repository_Tests
    {
        private ILogger logger;
        private IValidate<IStoreable<string>, string> validate;
        private ICollection<IStoreable<string>> storeableCollection = null;
        private IStoreable<string> firstStoreable;
        private IStoreable<string> secondStoreable;
        private Repository<IStoreable<string>, string> stringRepository;

        private void SetUpOneStoreable()
        {
            firstStoreable = new Storeable<string> { Id = "first" };
            storeableCollection = new Collection<IStoreable<string>>();

            SetUpCommonObjects();
        }

        private void SetUpOneStoreablePopulateCollection()
        {
            firstStoreable = new Storeable<string> { Id = "first" };
            storeableCollection = new Collection<IStoreable<string>> { firstStoreable };

            SetUpCommonObjects();
        }

        private void SetUpTwoStoreables()
        {
            firstStoreable = new Storeable<string> { Id = "first" };
            secondStoreable = new Storeable<string> { Id = "second" };
            storeableCollection = new Collection<IStoreable<string>>
            {
                firstStoreable,
                secondStoreable
            };

            SetUpCommonObjects();
        }

        private void SetUpCommonObjects()
        {
            logger = new Logger();
            validate = new Validate<IStoreable<string>, string>(logger);
            stringRepository = new Repository<IStoreable<string>, string>(storeableCollection, logger, validate);
        }

        [Test]
        public void StringRepository_SaveStorable_SetsCountToOne()
        {
            // Arrange
            SetUpOneStoreable();

            // Act
            stringRepository.Save(firstStoreable);

            // Assert
            Assert.That(storeableCollection.Count == 1);
        }

        [Test]
        public void StringRepository_SaveStorable_ThrowsArgumentNullException()
        {
            // Arrange
            SetUpOneStoreable();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => stringRepository.Save(null));

            // Assert
            Assert.That(ex.Message == "item cannot be null when calling Save on repository\r\nParameter name: Save");
        }

        [Test]
        public void StringRepository_SaveStorable_AlreadyExistsThrowsException()
        {
            // Arrange
            SetUpOneStoreablePopulateCollection();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => stringRepository.Save(firstStoreable));

            // Assert
            Assert.That(ex.Message == "item already exists in repository, when calling Save\r\nParameter name: Save");
        }

        [Test]
        public void StringRepository_GetStorable_ReturnsStoreable()
        {
            // Arrange
            SetUpOneStoreablePopulateCollection();

            // Act
            var returnedObject = stringRepository.Get(firstStoreable.Id);

            // Assert
            Assert.IsTrue(returnedObject.GetType() == typeof(Storeable<string>));
        }

        [Test]
        public void StringRepository_GetStorable_ThrowsArgumentNullException()
        {
            // Arrange
            SetUpOneStoreable();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => stringRepository.Get(null));

            // Assert
            Assert.That(ex.Message == "id cannot be null when calling Get on repository\r\nParameter name: Get");
        }

        [Test]
        public void StringRepository_GetAllStorable_SetsCountToTwo()
        {
            // Arrange
            SetUpTwoStoreables();

            // Act
            stringRepository.GetAll();

            // Assert
            Assert.That(storeableCollection.Count == 2);
        }

        [Test]
        public void StringRepository_DeleteStorable_SetsCountToOne()
        {
            // Arrange
            SetUpTwoStoreables();

            // Act
            stringRepository.Delete(secondStoreable.Id);

            // Assert
            Assert.That(storeableCollection.Count == 1);
        }

        [Test]
        public void StringRepository_DeleteStorable_ThrowsArgumentNullException()
        {
            // Arrange
            SetUpTwoStoreables();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => stringRepository.Delete(null));

            // Assert
            Assert.That(ex.Message == "id cannot be null when calling Delete on repository\r\nParameter name: Delete");
        }

        [Test]
        public void StringRepository_DeleteStorable_DoesntExistThrowsException()
        {
            // Arrange
            SetUpOneStoreable();
            secondStoreable = new Storeable<string> { Id = "second" };

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => stringRepository.Delete(secondStoreable.Id));

            // Assert
            Assert.That(ex.Message == "id does not exist in repository, when calling Delete\r\nParameter name: Delete");
        }
    }
}
