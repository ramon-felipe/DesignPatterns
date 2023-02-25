using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator
{

    public interface IPeopleIterator
    {
        Person First();
        Person Next();
        bool IsDone { get; }
        Person CurrentItem { get; }

    }

    public class PeopleIterator : IPeopleIterator
    {
        private readonly PeopleCollection _peopleCollection;
        private int _index = 0;

        public PeopleIterator(PeopleCollection collection)
        {
            _peopleCollection = collection;
        }

        public bool IsDone => _index >= _peopleCollection.Count;

        public Person CurrentItem => _peopleCollection.ElementAt(_index);

        public Person First()
        {
            _index = 0;

            return _peopleCollection.ElementAt(_index);
        }

        public Person Next()
        {
            return _peopleCollection.ElementAt(_index++);
        }
    }

    public interface IPeopleCollection
    {
        IPeopleIterator CreateIterator();
    }

    public class PeopleCollection : List<Person>, IPeopleCollection
    {
        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        }
    }
}
