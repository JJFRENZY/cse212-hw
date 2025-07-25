using System;
using System.Collections.Generic;

public class LinkedList
{
    private class Node
    {
        public int Value;
        public Node? Next;
        public Node? Prev;

        public Node(int value)
        {
            Value = value;
        }
    }

    private Node? head;
    private Node? tail;

    public void InsertHead(int value)
    {
        var node = new Node(value);

        if (head == null)
        {
            head = tail = node;
        }
        else
        {
            node.Next = head;
            head.Prev = node;
            head = node;
        }
    }

    public void InsertTail(int value)
    {
        var node = new Node(value);

        if (tail == null)
        {
            head = tail = node;
        }
        else
        {
            tail.Next = node;
            node.Prev = tail;
            tail = node;
        }
    }

    public void RemoveHead()
    {
        if (head == null) return;

        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            head = head.Next;
            if (head != null) head.Prev = null;
        }
    }

    public void RemoveTail()
    {
        if (tail == null) return;

        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.Prev;
            if (tail != null) tail.Next = null;
        }
    }

    public void InsertAfter(int target, int value)
    {
        for (var curr = head; curr != null; curr = curr.Next)
        {
            if (curr.Value == target)
            {
                var node = new Node(value)
                {
                    Next = curr.Next,
                    Prev = curr
                };

                if (curr.Next != null)
                    curr.Next.Prev = node;
                else
                    tail = node;

                curr.Next = node;
                break;
            }
        }
    }

    public void Remove(int value)
    {
        for (var curr = head; curr != null; curr = curr.Next)
        {
            if (curr.Value == value)
            {
                if (curr == head)
                {
                    RemoveHead();
                }
                else if (curr == tail)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                break; // Remove only first match
            }
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        for (var curr = head; curr != null; curr = curr.Next)
        {
            if (curr.Value == oldValue)
            {
                curr.Value = newValue;
            }
        }
    }

    public IEnumerable<int> Reverse()
    {
        for (var curr = tail; curr != null; curr = curr.Prev)
        {
            yield return curr.Value;
        }
    }

    public bool HeadAndTailAreNull() => head == null && tail == null;

    public bool HeadAndTailAreNotNull() => head != null && tail != null;

    public override string ToString()
    {
        var result = new List<int>();

        for (var curr = head; curr != null; curr = curr.Next)
        {
            result.Add(curr.Value);
        }

        return $"<LinkedList>{{{string.Join(", ", result)}}}";
    }
}
