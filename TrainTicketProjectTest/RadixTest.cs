using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTickeProject.Collection;

namespace TrainTicketProjectTest
{
    [TestClass]
    public class RadixTest
    {
        [TestMethod]
        public void TestRadixAddWithSingleCharStringTerm()
        {
            // Arrange
            var terms = new[] { "D" };
            var radix = new Radix();
            var expected = terms;

            // Act
            radix.Add(terms);
            var actual = radix.GetAllTerms();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }
        [TestMethod]
        public void TestRadixAddWithSingleTerm()
        {
            // Arrange
            var terms = new[] { "DA" };
            var radix = new Radix();
            var expected = terms;

            // Act
            radix.Add(terms);
            var actual = radix.GetAllTerms();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public void TestRadixAddWithMultipleTermsStartedWithSamePrefix()
        {
            // Arrange
            var terms = new[] { "DAR", "DEN" };
            var radix = new Radix();
            var expected = terms;

            // Act
            radix.Add(terms);
            var actual = radix.GetAllTerms();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());

        }

        [TestMethod]
        public void TestGetTermsWithSingleChar()
        {
            // Arrange
            var terms = new[] { "D" };
            var radix = new Radix(terms);

            var expected = terms;

            // Act
            var actual = radix.Find("D");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public void TestGetTermsWithSingleCharAndMultipleBranches()
        {
            // Arrange
            var terms = new[] { "DARTM", "DARTF" };
            var radix = new Radix(terms);

            var expected = terms;

            // Act
            var actual = radix.Find("D");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public void TestGetTermsWithFullTerm()
        {
            // Arrange
            var terms = new[] { "DA" };
            var radix = new Radix(terms);

            var expected = terms;

            // Act
            var actual = radix.Find("DA");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public void TestGetTermsWithFullTermAndBranch()
        {
            // Arrange
            var terms = new[] { "DART", "DARTS" };
            var radix = new Radix(terms);

            var expected = terms;

            // Act
            var actual = radix.Find("DART");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public void TestGetTermsWithPartialTermAndSingleBranche()
        {
            // Arrange
            var terms = new[] { "DARTFORD" };
            var radix = new Radix(terms);

            var expected = terms;

            // Act
            var actual = radix.Find("DA");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public void TestGetTermsWithPartialTermAndMultipleBranches()
        {
            // Arrange
            var terms = new[] { "DARTM", "DARTF" };
            var radix = new Radix(terms);

            var expected = terms;

            // Act
            var actual = radix.Find("DART");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }
    }
}
