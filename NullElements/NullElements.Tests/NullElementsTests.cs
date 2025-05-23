// <copyright file="NullElementsTests.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace NullElements.Tests
{
    public class NullElementsTests
    {
        [Test]
        public void Add_NumberToEmptyList_ShouldIncreaseCountByOne()
        {
            var testList = new MyList<int>();
            testList.Add(5);

            Assert.That(testList.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Overflow_ShouldDoubleInternalArraySize()
        {
            var testList = new MyList<int>();
            var initialCapacity = 10;
            for (int i = 0; i < initialCapacity + 1; ++i)
            {
                testList.Add(i);
            }

            Assert.That(testList.Count, Is.EqualTo(11));
        }

        [Test]
        public void GetEnumerator_ValidData_ShouldIterateInCorrectOrder()
        {
            var testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);

            var result = new System.Collections.Generic.List<int>();
            foreach (var item in testList)
            {
                result.Add(item);
            }

            Assert.That(result, Is.EqualTo(new[] { 1, 2 }));
        }

        [Test]
        public void GetEnumerator_WhenListIsEmpty_ShouldNotIterate()
        {
            var testList = new MyList<string>();

            var iterations = 0;
            foreach (var item in testList)
            {
                iterations++;
            }

            Assert.That(iterations, Is.EqualTo(0));
        }

        [Test]
        public void CountNulls_String_ShouldReturnCorrectCount()
        {
            var testList = new MyList<string>();
            testList.Add("hello");
            testList.Add(null);
            testList.Add(string.Empty);
            testList.Add("world");

            var result = Counter.CountNulls(testList, new StringNullChecker());

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void CountNulls_Int_ShouldReturnCorrectCountZeros()
        {
            var testList = new MyList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(0);

            var result = Counter.CountNulls(testList, new IntNullChecker());

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void CountNulls_WhenIntListIsEmpty_ShouldReturnZero()
        {
            var testList = new MyList<int>();

            var result = Counter.CountNulls(testList, new IntNullChecker());

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CountNulls_WhenStringListIsEmpty_ShouldReturnZero()
        {
            var testList = new MyList<string>();

            var result = Counter.CountNulls(testList, new StringNullChecker());

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
