using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class Enumerators
    {
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] people)
        {
            people.CopyTo(_people, 0);
        }

        public PeopleEnumerator GetEnumerator()
        {
            return new PeopleEnumerator(_people);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }

    public class PeopleEnumerator : IEnumerator
    {
        private Person[] _people;
        int position = -1;

        public PeopleEnumerator(Person[] people)
        {
            _people = people;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;        
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
