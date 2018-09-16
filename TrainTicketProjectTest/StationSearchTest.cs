using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTickeProject.Repository;
using TrainTickeProject.Result;
using TrainTickeProject.StationSearch;
using Moq;
using System.Linq;

namespace TrainTicketProjectTest
{
    [TestClass]
    public class StationSearchTest
    {
        [TestMethod]
        public void TestSearchStartingWithPartialStationName()
        {
            // Arrange
            var datasource = new List<string> { "DARTFORD", "DARTMOUTH", "TOWER HILL", "DERBY" };

            var mock = new Mock<IStationRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAllStartedWithName("DART"))
                .Returns((string name) => datasource.Where(s => s.StartsWith(name)).ToList());

            var expected = new StationSearchResult(new[] { 'F', 'M' }, new[] { "DARTFORD", "DARTMOUTH" });

            // Act
            var actual = new StationSearch(mock.Object).SearchStartingWith("DART");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchStartingWithFullStationName()
        {
            // Arrange
            var datasource = new List<string> { "DARTFORD", "LIVERPOOL", "PADDINGTON" };

            var mock = new Mock<IStationRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAllStartedWithName("LIVERPOOL"))
                .Returns((string name) => datasource.Where(s => s.StartsWith(name)).ToList());

            var expected = new StationSearchResult(new char[0], new[] { "LIVERPOOL" });

            // Act
            var actual = new StationSearch(mock.Object).SearchStartingWith("LIVERPOOL");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchStartingWithPartialStationNameAndSpaceAfter()
        {
            // Arrange
            var datasource = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" };

            var mock = new Mock<IStationRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAllStartedWithName("LIVERPOOL"))
                .Returns((string name) => datasource.Where(s => s.StartsWith(name)).ToList());

            var expected = new StationSearchResult(new[] { ' ' }, new[] { "LIVERPOOL", "LIVERPOOL LIME STREET" });

            // Act
            var actual = new StationSearch(mock.Object).SearchStartingWith("LIVERPOOL");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchStartingWithUnexistentStationName()
        {
            // Arrange
            var datasource = new List<string> { "EUSTON", "LONDON BRIDGE", "VICTORIA" };

            var mock = new Mock<IStationRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAllStartedWithName("KINGS CROSS"))
                .Returns((string name) => datasource.Where(s => s.StartsWith(name)).ToList());

            var expected = new StationSearchResult(new char[0], new string[0]);

            // Act
            var actual = new StationSearch(mock.Object).SearchStartingWith("KINGS CROSS");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
