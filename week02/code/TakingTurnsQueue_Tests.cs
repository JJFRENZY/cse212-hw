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
        queue.AddPerson("Charlie", -1); // Infinite turns

        Assert.AreEqual("Alice", queue.GetNextPerson().Name);   // Alice (1 left)
        Assert.AreEqual("Bob", queue.GetNextPerson().Name);     // Bob (0 left)
        Assert.AreEqual("Charlie", queue.GetNextPerson().Name); // Charlie
        Assert.AreEqual("Alice", queue.GetNextPerson().Name);   // Alice (0 left)
        Assert.AreEqual("Charlie", queue.GetNextPerson().Name); // Charlie
        Assert.AreEqual("Charlie", queue.GetNextPerson().Name); // Charlie
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestGetNextPerson_EmptyQueueThrows()
    {
        var queue = new TakingTurnsQueue();
        queue.GetNextPerson(); // Should throw
    }

    [TestMethod]
    public void TestInfiniteTurns()
    {
        var queue = new TakingTurnsQueue();

        queue.AddPerson("Eve", -1); // Infinite
        Assert.AreEqual("Eve", queue.GetNextPerson().Name);
        Assert.AreEqual("Eve", queue.GetNextPerson().Name);
        Assert.AreEqual("Eve", queue.GetNextPerson().Name);
    }

    [TestMethod]
    public void TestFinitePeopleRemoved()
    {
        var queue = new TakingTurnsQueue();

        queue.AddPerson("Tom", 1);
        queue.AddPerson("Jerry", 2);

        Assert.AreEqual("Tom", queue.GetNextPerson().Name);    // Tom removed (0)
        Assert.AreEqual("Jerry", queue.GetNextPerson().Name);  // Jerry (1)
        Assert.AreEqual("Jerry", queue.GetNextPerson().Name);  // Jerry (0)

        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
    }
}
