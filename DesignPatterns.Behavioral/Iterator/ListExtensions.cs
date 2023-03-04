using DesignPatterns.Behavioral.GenericIterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator
{
    public static class ListExtensions
    {
        public static IIterator<T> AsIterator<T>(this IEnumerable<T> collection)
        {
            if (collection == null || !collection.Any())
                return new GenericCollection<T>().CreateIterator();

            var newCollection = new GenericCollection<T>();
            newCollection.AddRange(collection);
            var iterator = newCollection.CreateIterator();

            return iterator;
        }
    }
}
