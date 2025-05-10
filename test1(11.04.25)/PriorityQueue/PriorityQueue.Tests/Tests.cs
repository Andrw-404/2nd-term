// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600

namespace PriorityQueue.Tests
{
    public class Tests
    {
        [Test]
        public void Dequeu_IntegerValue_ShouldReturnCorrectValues()
        {
            var testQueue = new Queue<int>();
            testQueue.Enqueue(13, 1);
            testQueue.Enqueue(32, 3);
            testQueue.Enqueue(55, 2);

            Assert.That(testQueue.Dequeue, Is.EqualTo(13));
            Assert.That(testQueue.Dequeue, Is.EqualTo(55));
            Assert.That(testQueue.Dequeue, Is.EqualTo(32));
        }

        [Test]
        public void Dequeu_StringValue_ShouldReturnCorrectValues()
        {
            var testQueue = new Queue<string>();
            testQueue.Enqueue("das", 1);
            testQueue.Enqueue("fdsfsd", 3);
            testQueue.Enqueue("dsad", 2);

            Assert.That(testQueue.Dequeue, Is.EqualTo("das"));
            Assert.That(testQueue.Dequeue, Is.EqualTo("dsad"));
            Assert.That(testQueue.Dequeue, Is.EqualTo("fdsfsd"));
        }

        [Test]
        public void Dequeu_EmptyQueue_ShouldThrowAnException()
        {
            var testQueue = new Queue<bool>();
            Assert.Throws<InvalidDataException>(() => testQueue.Dequeue());
        }
    }
}
