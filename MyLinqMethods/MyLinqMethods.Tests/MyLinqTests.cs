// <copyright file="MyLinqTests.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace MyLinqMethods.Tests
{
    public class MyLinqTests
    {
        private List<int> source;

        [SetUp]
        public void SetUp()
        {
            this.source = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        [Test]
        public void GetPrimes_FirstFewElements_ShouldReturnCorrectPrimeNumbers()
        {
            var expected = new List<int> { 2, 3, 5, 7, 11 };
            var result = new List<int>();

            foreach (var element in MyLinqMethods.GetPrimes())
            {
                result.Add(element);

                if (result.Count == expected.Count)
                {
                    break;
                }
            }

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Take_ValidData_ShouldReturnCorrectSequence()
        {
            var expected = new List<int> { 1, 2, 3, 4 };
            var result = this.source.Take(4).ToList();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Take_ZeroNumber_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.source.Take(0).ToList());
        }

        [Test]
        public void Take_NegativeNumber_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.source.Take(-3).ToList());
        }

        [Test]
        public void Take_EmptySequence_ShouldReturnEmptySequence()
        {
            var emptyList = new List<int>();
            var result = emptyList.Take(3).ToList();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Skip_ValidData_ShouldReturnCorrectSequence()
        {
            var expected = new List<int> { 6, 7, 8, 9 };
            var result = this.source.Skip(5).ToList();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Skip_ZeroNumber_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.source.Skip(0).ToList());
        }

        [Test]
        public void Skip_NegativeNumber_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.source.Skip(-3).ToList());
        }

        [Test]
        public void Skip_EmptySequence_ShouldReturnEmptySequence()
        {
            var emptyList = new List<int>();
            var result = emptyList.Skip(3).ToList();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void TakeAndSkip_ValidData_ShouldReturnCorrectSequence()
        {
            var expected = new List<int> { 4, 5, 6, 7 };
            var result = this.source.Skip(3).Take(4).ToList();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
