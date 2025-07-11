using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    public void TestEnqueueDequeue()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("LowPriority", 1);
        pq.Enqueue("MediumPriority", 5);
        pq.Enqueue("HighPriority", 10);
        pq.Enqueue("SameHighPriority", 10);

        // Dequeue should return item with highest priority (last added with highest priority)
        var first = pq.Dequeue();
        Assert.AreEqual("SameHighPriority", first);

        // Next highest priority is HighPriority (priority 10)
        var second = pq.Dequeue();
        Assert.AreEqual("HighPriority", second);

        // Next is MediumPriority (priority 5)
        var third = pq.Dequeue();
        Assert.AreEqual("MediumPriority", third);

        // Last is LowPriority (priority 1)
        var fourth = pq.Dequeue();
        Assert.AreEqual("LowPriority", fourth);

        // Queue is empty now, next Dequeue throws
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    public void TestToString()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 2);

        var str = pq.ToString();
        StringAssert.Contains(str, "A (Pri:3)");
        StringAssert.Contains(str, "B (Pri:2)");
    }
}
