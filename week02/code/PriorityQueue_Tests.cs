using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items and their priorities: Bob (2), Tim (5), Sue (3) 
    // and run until the queue is empty
    // Expected Result: Tim, Sue, Bob
    // Defect(s) Found: Last element was not being checked for highest priority, and the item with the highest priority was not being removed from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        string[] expectedResult = ["Tim", "Sue", "Bob"];   

        for(int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], item);
        }
    }

    [TestMethod]
    // Scenario: Create a queue where two items have the same highest priority: Bob (3), Tim (5), Sue (5) 
    // and run until the queue is empty
    // Expected Result: Tim, Sue, Bob
    // Defect(s) Found: When indexes had the same priority, the first one was not being selected as the highest priority item to be removed from the queue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 5);

        string[] expectedResult = ["Tim", "Sue", "Bob"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], item);
        }
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found:
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
       
       try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Dequeue should have thrown an exception since the queue is empty.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}