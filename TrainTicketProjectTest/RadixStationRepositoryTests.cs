using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTickeProject.Repository;

namespace TrainTicketProjectTest
{
    [TestClass]
    public class RadixStationRepositoryTests
    {
        [TestMethod]
        public void TestGetAllStartedWithPartialStationName()
        {
            // Arrange
            var datasource = new List<string> { "DARTFORD", "DARTMOUTH", "TOWER HILL", "DERBY" };
            var expected = new List<string> { "DARTFORD", "DARTMOUTH" };

            // Act
            var actual = new RadixStationRepository(datasource).GetAllStartedWithName("DART");

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestGetAllStartedWithFullStationName()
        {
            // Arrange
            var datasource = new List<string> { "DARTFORD", "LIVERPOOL", "PADDINGTON" };
            var expected = new List<string> { "LIVERPOOL" };

            // Act
            var actual = new RadixStationRepository(datasource).GetAllStartedWithName("LIVERPOOL");

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestGetAllStartedWithPartialStationNameAndSpaceAfter()
        {
            // Arrange
            var datasource = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" };
            var expected = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET" };

            // Act
            var actual = new RadixStationRepository(datasource).GetAllStartedWithName("LIVERPOOL");

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestGetAllStartedWithUnexistentStationName()
        {
            // Arrange
            var datasource = new List<string> { "EUSTON", "LONDON BRIDGE", "VICTORIA" };
            var expected = new List<string>(0);

            // Act
            var actual = new RadixStationRepository(datasource).GetAllStartedWithName("KINGS CROSS");

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
