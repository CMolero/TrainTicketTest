using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTickeProject.Result;

namespace TrainTicketProjectTest
{
    [TestClass]
    public class StationSearchResultTest
    {
        [TestMethod]
        public void TestEqualsWithEqualObjects()
        {
            // Arrange

            // Act
            var actual = new StationSearchResult(new[] { 'A' }, new[] { "ABC" })
                .Equals(new StationSearchResult(new[] { 'A' }, new[] { "ABC" }));

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestEqualsWithDiferentObjects()
        {
            // Arrange

            // Act
            var actual = new StationSearchResult(new[] { 'A' }, new[] { "ABC" })
                .Equals(new StationSearchResult(new[] { 'B' }, new[] { "ABC" }));

            // Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestEqualsWithSameObject()
        {
            // Arrange
            var obj = new StationSearchResult(new[] { 'A' }, new[] { "ABC" });
            var obj2 = obj;

            // Act
            var actual = obj.Equals(obj2);

            // Assert
            Assert.AreEqual(true, actual);
        }
    }
}
