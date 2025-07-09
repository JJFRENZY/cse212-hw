using System;
using System.Collections.Generic;

/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test 1: Add customers until full
        Console.WriteLine("Test 1: Add customers until full");
        var cs = new CustomerService(2);
        cs.TestAddCustomer("Alice", "A001", "Password reset");
        cs.TestAddCustomer("Bob", "B002", "Cannot login");
        cs.TestAddCustomer("Charlie", "C003", "App crashes"); // Should be rejected
        Console.WriteLine(cs);
        Console.WriteLine("=================");

        // Test 2: Serve customers
        Console.WriteLine("Test 2: Serve customers");
        cs.TestServeCustomer(); // Alice
        cs.TestServeCustomer(); // Bob
        cs.TestServeCustomer(); // None left
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class. Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  
    /// Put the new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging.
    /// </summary>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }

    // -------------------------------
    // Test Helper Methods
    // -------------------------------

    public void TestAddCustomer(string name, string id, string problem) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, id, problem);
        _queue.Add(customer);
    }

    public void TestServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }
}
