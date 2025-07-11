using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> _people = new Queue<Person>();

    public void AddPerson(string name, int turns)
    {
        _people.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Decrement only if turns are positive
        if (person.Turns > 0)
        {
            person.Turns -= 1;
        }

        // Re-enqueue if they have infinite turns or still have turns left
        if (person.Turns != 0)
        {
            _people.Enqueue(person);
        }

        return person;
    }
}
