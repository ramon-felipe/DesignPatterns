using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.GenericIterator
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        bool IsDone { get; }
        T CurrentItem { get; }
    }

    public class CollectionIterator<T> : IIterator<T>
    {
        private readonly GenericCollection<T> _collection;
        private int _index = 0;

        public CollectionIterator(GenericCollection<T> collection)
        {
            _collection = collection;
        }

        public bool IsDone => _index >= _collection.Count;

        public T CurrentItem => _collection.ElementAt(_index);

        public T First()
        {
            _index = 0;

            return _collection.ElementAt(_index);
        }

        public T Next()
        {
            return _collection.ElementAt(_index++);
        }
    }

    public interface IItemCollection<T>
    {
        IIterator<T> CreateIterator();
    }

    public class GenericCollection<T> : List<T>, IItemCollection<T>
    {
        public IIterator<T> CreateIterator()
        {
            return new CollectionIterator<T>(this);
        }
    }
}
