using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueue_Tests
{
    [TestMethod]
    public void TestAddAndGetNextPerson()
    {
        var queue = new TakingTurnsQueue();

        queue.AddPerson("Alice", 2);
        queue.AddPerson("Bob", 1);
        queue.AddPerson("Charlie", 0);

        // 1st person: Alice (turns 2)
        var p1 = queue.GetNextPerson();
        Assert.AreEqual("Alice", p1.Name);
        Assert.AreEqual(1, p1.Turns);

        // 2nd person: Bob (turns 1, no re-enqueue)
        var p2 = queue.GetNextPerson();
        Assert.AreEqual("Bob", p2.Name);
        Assert.AreEqual(1, p2.Turns); // turns still 1 since we return before decrementing?

        // 3rd person: Charlie (infinite turns)
        var p3 = queue.GetNextPerson();
        Assert.AreEqual("Charlie", p3.Name);
        Assert.AreEqual(0, p3.Turns);

        // 4th person: Alice again (turns now 1, after decrement)
        var p4 = queue.GetNextPerson();
        Assert.AreEqual("Alice", p4.Name);
        Assert.AreEqual(0, p4.Turns);
    }

    [TestMethod]
    public void TestGetNextPerson_EmptyQueueThrows()
    {
        var queue = new TakingTurnsQueue();

        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
    }
}
